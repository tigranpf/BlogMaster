using Azure.Core;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.Tags;
using BlogMaster.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.Tags
{
    public class EfDeleteTagCommand : EfUseCase, IDeleteTagCommand
    {
        public EfDeleteTagCommand(BMContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Delete tag";

        public string Description => "Delete tag";

        public void Execute(int data)
        {
            var tag = Context.Tags.Find(data);
            if (tag != null) { 
            tag.IsActive = false;
                Context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException("Tag", data);
            }
            
        }
    }
}
