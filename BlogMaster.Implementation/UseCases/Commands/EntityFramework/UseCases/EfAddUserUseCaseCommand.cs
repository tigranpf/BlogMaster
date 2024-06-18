using BlogMaster.Application.DTO.UseCases;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.UseCases;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.UseCases
{
    public class EfAddUserUseCaseCommand : EfUseCase, IAddUserUseCaseCommand
    {
        public EfAddUserUseCaseCommand(BMContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Add UserUseCase";

        public string Description => "Add single UseCase to User";

        public void Execute(AddUserUseCaseDTO data)
        {
            var user = Context.Users.Find(data.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }
            else
            {
                var ifAlreadyExists = Context.UserUseCases
                    .Where(x => x.UserId == data.UserId && x.UseCaseId == data.UseCaseId).FirstOrDefault();

                if (ifAlreadyExists != null)
                {
                    throw new ConflictException("User already has this usecase");
                }
            }

            Context.UserUseCases.Add(new UserUseCase
            {
                UseCaseId = data.UseCaseId,
                UserId = data.UserId
            });

            Context.SaveChanges();
        }
    }
}
