using BlogMaster.Application;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.BlogPosts;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostCommands
{
    public class EfDeleteBlogPostCommand : EfUseCase, IDeleteBlogPostCommand
    {
        IApplicationActor _actor;
        public EfDeleteBlogPostCommand(BMContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "Delete blog post";

        public string Description => "Delete blog post with Id provided";

        public void Execute(int data)
        {
            BlogPost blogPostToDelete = null;

            if (_actor.Role != "admin")
            {
                blogPostToDelete = Context.BlogPosts.
                       FirstOrDefault(x => x.Id == data && x.UserId == _actor.Id);
            }
            else
            {
                blogPostToDelete = Context.BlogPosts.FirstOrDefault(x => x.Id == data);
            }

            if (blogPostToDelete == null)
            {
                throw new EntityNotFoundException("BlogPost", data);
            }

            if (_actor != null && _actor.Role != "admin")
            {
                if (blogPostToDelete.UserId != _actor.Id)
                {
                    throw new ForbiddenOperationException(this.Name, _actor.Username);
                }
            }

            try
            {
                Context.Remove(blogPostToDelete);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ConflictException("Blog has restrict relations.");
            }
        }
    }
}
