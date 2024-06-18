using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Validators
{
    public class EditBlogPostValidator : AbstractValidator<EditBlogPostDTO>
    {
        public EditBlogPostValidator(BMContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Blog post ID must be provided")
                .Must(id => context.BlogPosts.Any(blog => blog.Id == id))
                .WithMessage("The blog post does not exist in the database");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Blog text must not be empty")
                .MaximumLength(3528).WithMessage("Blog text cannot exceed 3528 characters");

            RuleFor(x => x.Images)
                .Must(images => images.All(image => context.Images.Any(dbImage => dbImage.Id == image.Id)))
                .WithMessage("One or more images do not exist in the database");

            RuleFor(x => x.Tags)
                .Must(tags => tags.All(tag => context.Tags.Any(dbTag => dbTag.Id == tag.Id)))
                .WithMessage("One or more tags do not exist in the database");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Blog title must not be empty")
                .MaximumLength(200).WithMessage("Blog title cannot exceed 200 characters");
        }
    }
}
