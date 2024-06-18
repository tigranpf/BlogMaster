using Azure.Core;
using BlogMaster.Application;
using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.BlogPosts;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostCommands
{
    public class EfEditBlogPostCommand : EfUseCase, IEditBlogPostCommand
    {
        IApplicationActor _actor;
        EditBlogPostValidator Validator { get; }

        public EfEditBlogPostCommand(BMContext context, EditBlogPostValidator validator, IApplicationActor actor) : base(context)
        {
            _actor = actor;
            Validator = validator;

        }

        public int Id => 4;

        public string Name => "Edit Blog Post";

        public string Description => "Edit blog post.";

        public void Execute(EditBlogPostDTO data)
        {
            var blogPostToEdit = Context.BlogPosts.Include(x => x.BlogPostImages)
                                          .Include(x => x.BlogPostTags)
                                          .FirstOrDefault(x => x.Id == data.Id);

            if (blogPostToEdit == null)
            {
                throw new EntityNotFoundException("Blog Post", data.Id);
            }

            if (blogPostToEdit.UserId != _actor.Id && _actor.Role != "admin")
            {
                throw new ForbiddenOperationException(Name + " that is not yours", _actor.Email);
            }
            Validator.ValidateAndThrow(data);

            blogPostToEdit.Title = data.Title;
            blogPostToEdit.Text = data.Text;
            blogPostToEdit.UpdatedAt = DateTime.UtcNow;


            Context.BlogPostTags.RemoveRange(blogPostToEdit.BlogPostTags);
            foreach (var tagDto in data.Tags)
            {
                var blogPostTag = new BlogPostTag
                {
                    BlogPost = blogPostToEdit,
                    TagId = tagDto.Id
                };
                Context.BlogPostTags.Add(blogPostTag);
            }


            Context.BlogPostImages.RemoveRange(blogPostToEdit.BlogPostImages);
            foreach (var imageDto in data.Images)
            {
                var blogPostImage = new BlogPostImage
                {
                    BlogPost = blogPostToEdit,
                    ImageId = imageDto.Id
                };
                Context.BlogPostImages.Add(blogPostImage);
            }


            Context.Entry(blogPostToEdit).State = EntityState.Modified;

            Context.SaveChanges();

        }
    }
}
