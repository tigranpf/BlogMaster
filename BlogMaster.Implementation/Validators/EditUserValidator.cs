using BlogMaster.Application.DTO.Users;
using BlogMaster.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDTO>
    {
        private readonly BMContext _context;

        public EditUserValidator(BMContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(UserExists).WithMessage("User does not exist.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .Must((dto, email) => BeUniqueEmail(dto.UserId, email)).WithMessage("Email is already in use.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.FirstName)
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.FirstName));

            RuleFor(x => x.LastName)
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.LastName));

            RuleFor(x => x.Password)
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Password must be at least eight characters long, with at least one uppercase letter, one lowercase letter, and one number.")
                .When(x => !string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.Username)
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Must be 4-15 characters, containing only letters, numbers, underscores, or periods, and cannot start or end with an underscore or period.")
                .Must((dto, username) => BeUniqueUsername(dto.UserId, username)).WithMessage("Username is already in use.")
                .When(x => !string.IsNullOrEmpty(x.Username));
        }

        private bool BeUniqueEmail(int userId, string email)
        {
            return !_context.Users.Any(u => u.Email == email && u.Id != userId);
        }

        private bool BeUniqueUsername(int userId, string username)
        {
            return !_context.Users.Any(u => u.Username == username && u.Id != userId);
        }

        private bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }
    }
}
