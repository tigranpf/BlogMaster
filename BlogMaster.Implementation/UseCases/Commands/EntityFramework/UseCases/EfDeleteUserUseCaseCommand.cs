using BlogMaster.Application.DTO.UseCases;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.UseCases;
using BlogMaster.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.UseCases
{
    public class EfDeleteUserUseCaseCommand : EfUseCase, IDeleteUserUseCaseCommand
    {
        public EfDeleteUserUseCaseCommand(BMContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Delete UserUseCase";

        public string Description => "Delete single UseCase from User";

        public void Execute(DeleteUserUseCaseDTO data)
        {
            var user = Context.Users.Find(data.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }

            var objToDelete = Context.UserUseCases.Where(x => x.UseCaseId == data.UseCaseId &&
                                               x.UserId == data.UserId).FirstOrDefault();

            if (objToDelete == null)
            {
                throw new EntityNotFoundException("UseCase", data.UseCaseId);
            }

            Context.UserUseCases.Remove(objToDelete);

            Context.SaveChanges();
        }
    }
}
