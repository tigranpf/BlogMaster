using BlogMaster.Application;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.Users;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.UserCommands
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        IApplicationActor _actor;
        public EfDeleteUserCommand(BMContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 9;

        public string Name => "Delete user";

        public string Description => "Only admin can delete user";

        public void Execute(int data)
        {
            User userToDelete = null;

            if (_actor.Role == "admin")
            {
                userToDelete = Context.Users.
                       FirstOrDefault(x => x.Id == data);
            }
            else
            {
                throw new ForbiddenOperationException(this.Name, _actor.Username);
            }

            if (userToDelete == null)
            {
                throw new EntityNotFoundException("User", data);
            }

            

            try
            {
                Context.Remove(userToDelete);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ConflictException("User has restrict relations.");
            }
        }
    }
}
