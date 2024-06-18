using BlogMaster.Application;
using BlogMaster.Application.DTO.BlogPostReactions;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.BlogPostReactions;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostReactionCommands
{
    public class EfAddBlogPostReactionCommand : EfUseCase, IAddBlogPostReactionCommand
    {
        IApplicationActor _actor;
        BlogPostReactionValidator _validator;
        public EfAddBlogPostReactionCommand(BMContext context, IApplicationActor actor, BlogPostReactionValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Add BlogPost Reaction";

        public string Description => "Add reaction to BlogPost";

        public void Execute(ReactOnBlogDTO data)
        {
            _validator.ValidateAndThrow(data);

            var existingReaction = Context.BlogPostReactions
                                    .FirstOrDefault(r => r.BlogPostId == data.BlogPostId && r.ReactionId == data.ReactionId && r.UserId == _actor.Id);

            if (existingReaction != null)
            {
                throw new ConflictException("User has already reacted to this blog post with the same reaction.");
            }

            var blogPostReaction = new BlogPostReaction
            {
                BlogPostId = data.BlogPostId,
                ReactionId = data.ReactionId,
                UserId = _actor.Id
            };

            Context.BlogPostReactions.Add(blogPostReaction);
            Context.SaveChanges();
        }
    }
}
