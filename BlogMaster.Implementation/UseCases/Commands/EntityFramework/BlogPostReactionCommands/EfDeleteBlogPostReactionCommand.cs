using BlogMaster.Application;
using BlogMaster.Application.DTO.BlogPostReactions;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.BlogPostReactions;
using BlogMaster.DataAccess;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostReactionCommands
{
    public class EfDeleteBlogPostReactionCommand : EfUseCase, IDeleteBlogPostReactionCommand
    {
        IApplicationActor _actor;
        BlogPostReactionValidator _validator;
        public EfDeleteBlogPostReactionCommand(BMContext context, IApplicationActor actor, BlogPostReactionValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Delete BlogPost reaction";

        public string Description => "Delete reaction from blog post";

        public void Execute(ReactOnBlogDTO data)
        {
            _validator.ValidateAndThrow(data);

            

            var blogPostReaction = Context.BlogPostReactions
                .FirstOrDefault(r => r.BlogPostId == data.BlogPostId && r.ReactionId == data.ReactionId && r.UserId == _actor.Id);

            if (blogPostReaction == null)
            {
                throw new ConflictException("The reaction does not exist for the current user on this blog post.");
            }

            Context.BlogPostReactions.Remove(blogPostReaction);
            Context.SaveChanges();
        }
    }
}
