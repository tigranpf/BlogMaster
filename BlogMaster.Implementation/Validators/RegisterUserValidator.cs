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
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly BMContext _context;

        public RegisterUserValidator(BMContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(BeUniqueEmail).WithMessage("Email is already in use.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Password must be at least eight characters long, with at least one uppercase letter, one lowercase letter, and one number.");
          
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Must be 4-15 characters, containing only letters, numbers, underscores, or periods, and cannot start or end with an underscore or period.")
                .Must(BeUniqueUsername).WithMessage("Username is already in use.");
        }

        private bool BeUniqueEmail(string email)
        {
            return !_context.Users.Any(u => u.Email == email);
        }
     
        private bool BeUniqueUsername(string username)
        {
            return !_context.Users.Any(u => u.Username == username);
        }
    }
}
