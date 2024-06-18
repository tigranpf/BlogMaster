using Azure.Core;
using BlogMaster.Application.DTO.Users;
using BlogMaster.Application.UseCases.Commands.Users;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.UserCommands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;

        public EfRegisterUserCommand(BMContext context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Register user";

        public string Description => "Register user";

        public void Execute(RegisterUserDto data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {
                BirthDate = data.BirthDate.Value,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                RoleId = 3,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Username = data.Username,
                UserUseCases = new List<UserUseCase>()
            };

            if (!string.IsNullOrEmpty(data.ProfilePicturePath))
            {
                var image = new Image { Path = data.ProfilePicturePath };
                user.ProfilePicture = new Image
                {
                    Path = image.Path,
                    Description = "Profile picture"
                };
            }


                var userRoleUseCases = new List<int> { 1, 2, 3, 4, 5, 6, 7, 15, 16 }; 

            foreach (var useCaseId in userRoleUseCases)
            {
                user.UserUseCases.Add(new UserUseCase
                {
                    UseCaseId = useCaseId
                });
            }

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
