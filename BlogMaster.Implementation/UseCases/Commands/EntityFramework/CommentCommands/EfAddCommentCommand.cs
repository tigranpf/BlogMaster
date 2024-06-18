using BlogMaster.Application;
using BlogMaster.Application.DTO.Comments;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.Comments;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.CommentCommands
{
    public class EfAddCommentCommand : EfUseCase, IAddCommentCommand
    {
        IApplicationActor _actor;
        public EfAddCommentCommand(BMContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 6;

        public string Name => "Add comment";

        public string Description => "Add new comment.";

        public void Execute(AddCommentDTO data)
        {

            var blogPost = Context.BlogPosts.Find(data.BlogPostId);
            if (blogPost == null)
            {
                throw new EntityNotFoundException("Blog", data.BlogPostId);
            }

            if (data.ParentId.HasValue && data.ParentId.Value != 0)
            {
                var parentComment = Context.Comments
                                           .FirstOrDefault(c => c.Id == data.ParentId.Value);

                if (parentComment == null)
                {
                    throw new EntityNotFoundException("Parent Comment", data.ParentId.Value);
                }

                if (parentComment.BlogPostId != data.BlogPostId)
                {
                    throw new ConflictException("Parent comment does not belong to the specified blog post.");
                }

                if (parentComment.ParentId.HasValue)
                {
                    throw new ConflictException("Nested comments are not allowed.");
                }
            }

            if (string.IsNullOrWhiteSpace(data.Text))
            {
                throw new ConflictException("No empty comments are allowed.");

            }

            var newComment = new Comment
            {
                UserId = _actor.Id,
                Text = data.Text,
                BlogPostId = data.BlogPostId,
                ParentId = data.ParentId.HasValue && data.ParentId.Value != 0 ? data.ParentId : null,
                CreatedAt = DateTime.UtcNow
            };

            Context.Add(newComment);
            Context.SaveChanges();
        }
    }
}
