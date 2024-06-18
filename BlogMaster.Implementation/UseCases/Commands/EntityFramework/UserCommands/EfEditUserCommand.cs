using BlogMaster.Application;
using BlogMaster.Application.DTO.Users;
using BlogMaster.Application.UseCases.Commands.Users;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.UserCommands
{
    public class EfEditUserCommand : EfUseCase, IEditUserCommand
    {
        IApplicationActor _actor;
        EditUserValidator _validator;
        public EfEditUserCommand(BMContext context, IApplicationActor actor, EditUserValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;

        }

        public int Id => 10;

        public string Name => "Edit user command";

        public string Description => "Only admin can edit all user's info";

        public void Execute(EditUserDTO data)
        {
            var user = Context.Users.Include(u => u.UserUseCases).FirstOrDefault(u => u.Id == data.UserId);
          
            _validator.ValidateAndThrow(data);

            user.BirthDate = data.BirthDate ?? user.BirthDate;  
            user.Email = data.Email ?? user.Email;              
            user.FirstName = data.FirstName ?? user.FirstName;  
            user.LastName = data.LastName ?? user.LastName;     
            user.RoleId = data.RoleId ?? user.RoleId;           
            user.ProfilePictureId = data.ProfilePictureId ?? user.ProfilePictureId; 
            user.Username = data.Username ?? user.Username;     

            if (!string.IsNullOrEmpty(data.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            }



            if (data.UserUseCases != null)
            {
                user.UserUseCases.Clear();

                foreach (var useCaseId in data.UserUseCases)
                {
                    user.UserUseCases.Add(new UserUseCase
                    {
                        UseCaseId = useCaseId
                    });
                }
            }

            Context.SaveChanges();
        }
    }
}
