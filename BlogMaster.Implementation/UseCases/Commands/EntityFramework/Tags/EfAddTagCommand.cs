using Azure.Core;
using BlogMaster.Application.DTO.Tags;
using BlogMaster.Application.UseCases.Commands.Tags;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.Tags
{
    public class EfAddTagCommand : EfUseCase, IAddTagCommand
    {
        private AddTagValidator _validator;

        public EfAddTagCommand(BMContext context, AddTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Add tag";
        public string Description => "Add tag";

        public void Execute(AddTagDTO data)
        {
            _validator.ValidateAndThrow(data);
           

            Tag tag = new Tag
            {
                Title = data.Title,
            };


            Context.Tags.Add(tag);

            Context.SaveChanges();
        }
    }
}
