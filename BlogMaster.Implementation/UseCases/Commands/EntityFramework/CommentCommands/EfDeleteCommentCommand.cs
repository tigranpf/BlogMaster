using BlogMaster.Application;
using BlogMaster.Application.DTO.Comments;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Commands.Comments;
using BlogMaster.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Commands.EntityFramework.CommentCommands
{
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        IApplicationActor _actor;
        public EfDeleteCommentCommand(BMContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 7;

        public string Name => "Delete comment";

        public string Description => "Admin and moderator can delete everybody's comment but user can delete only his.";

        public void Execute(int data)
        {
            var comment = Context.Comments
                                 .Include(c => c.Children)
                                 .FirstOrDefault(c => c.Id == data);

            if (comment == null)
            {
                throw new EntityNotFoundException("Comment", data);
            }

            if (comment.UserId != _actor.Id && _actor.Role != "admin" && _actor.Role != "moderator")
            {
                throw new ForbiddenOperationException("You are not allowed to delete this comment", _actor.Email);
            }

            if (comment.Children != null && comment.Children.Any())
            {
                throw new ConflictException("Cannot delete a comment that has replies.");
            }

            Context.Comments.Remove(comment);
            Context.SaveChanges();
        }
    }
}
