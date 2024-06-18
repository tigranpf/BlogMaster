using BlogMaster.Application.DTO.BlogPostReactions;
using BlogMaster.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Validators
{
    public class BlogPostReactionValidator : AbstractValidator<ReactOnBlogDTO>
    {
        public BlogPostReactionValidator(BMContext context)
        {
            RuleFor(x => x.BlogPostId)
                .Must(id => context.BlogPosts.Any(bp => bp.Id == id))
                .WithMessage("BlogPost with id {PropertyValue} does not exist.");

            RuleFor(x => x.ReactionId)
                .Must(id => context.Reactions.Any(r => r.Id == id))
                .WithMessage("Reaction with id {PropertyValue} does not exist.");
            
        }
    }
}
