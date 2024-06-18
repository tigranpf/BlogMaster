using BlogMaster.Application;
using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.BlogPosts;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostCommands
{
    public class EfAddBlogPostCommand : EfUseCase, IAddBlogPostCommand
    {
        IApplicationActor _actor;
        AddBlogPostValidator Validator { get; }
        public EfAddBlogPostCommand(BMContext context, AddBlogPostValidator validator, IApplicationActor actor) : base(context)
        {
            Validator = validator;
            _actor = actor;
        }

        public int Id => 3;

        public string Name => "Add Blog Post";

        public string Description => "User adding new blog post.";

        public void Execute(AddBlogPostDTO data)
        {
            var objUser = Context.Users.Find(_actor.Id);

            if (objUser == null)
            {
                throw new EntityNotFoundException("Users", _actor.Id);
            }

            var blogPostToAdd = data;

            Validator.ValidateAndThrow(blogPostToAdd);

            var blogPost = new BlogPost
            {
                Title = blogPostToAdd.Title,
                Text = blogPostToAdd.Text,
                UserId = _actor.Id,
            };

            foreach (var tagDto in data.Tags)
            {
                var blogPostTag = new BlogPostTag
                {
                    BlogPost = blogPost,
                    TagId = tagDto.Id
                };
                Context.BlogPostTags.Add(blogPostTag);
            }

            foreach (var imageDto in data.Images)
            {
                var blogPostImage = new BlogPostImage
                {
                    BlogPost = blogPost,
                    ImageId = imageDto.Id
                };
                Context.BlogPostImages.Add(blogPostImage);
            }
            Context.BlogPosts.Add(blogPost);

            Context.SaveChanges();
        }
    }
}
