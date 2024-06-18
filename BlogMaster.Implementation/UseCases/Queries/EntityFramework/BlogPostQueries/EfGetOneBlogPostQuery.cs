using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlogMaster.Implementation.UseCases.Queries.EntityFramework.BlogPostQueries
{
    public class EfGetOneBlogPostQuery : EfUseCase, IGetOneBlogPostQuery
    {
        public EfGetOneBlogPostQuery(BMContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Get single blog post.";

        public string Description => "Getting single blog post by id.";
        public BlogPostDTO Execute(int search)
        {
            BlogPost blogPost = Context.BlogPosts.FirstOrDefault(x => x.Id == search);

            var singleBlog = new BlogPostDTO
            {
                CreatedAt = blogPost.CreatedAt,
                Text = blogPost.Text,
                Username = Context.Users.Where(x => x.Id == blogPost.UserId).Select(x => x.Username).First(),
                FullName = Context.Users.Where(x => x.Id == blogPost.UserId).Select(x => x.FirstName).First() + " " + Context.Users.Where(x => x.Id == blogPost.UserId).Select(x => x.LastName).First(),
                CommentsCount = Context.Comments.Where(x => x.BlogPostId == blogPost.Id).Count(),
                ReactionsCount = Context.BlogPostReactions.Where(x => x.BlogPostId == blogPost.Id).Count(),
                Images = Context.BlogPostImages.Where(x => x.BlogPostId == blogPost.Id).Select(x => new BlogPostImageDTO
                {
                   Path = x.Image.Path,
                   Description = x.Image.Description
                 }).ToList(),
                Tags = Context.BlogPostTags.Where(x => x.BlogPostId == blogPost.Id).Select(x => new BlogPostTagDTO
                {
                    Title = x.Tag.Title,
                    Id = x.Tag.Id
                }).ToList(),
                Comments = Context.Comments.Where(x => x.BlogPostId == blogPost.Id).Select(x => new BlogPostCommentDTO
                {
                    ParentId = x.ParentId,
                    Text = x.Text,
                    Username = x.User.Username,
                    UserProfilePicture = x.User.ProfilePicture.Path
                }).ToList(),
                Reactions = Context.BlogPostReactions.Where(x => x.BlogPostId == blogPost.Id).Select(x => new BlogPostReactionDTO
                {
                    Username = x.User.Username,
                    Reaction = x.Reaction.Title

                }).ToList()

            };
            return singleBlog;
        }
    }
}
