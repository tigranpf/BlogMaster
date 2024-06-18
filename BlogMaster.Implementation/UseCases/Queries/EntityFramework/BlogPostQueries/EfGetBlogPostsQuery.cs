using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.DTO.Pagination;
using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using BlogMaster.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster.Implementation.UseCases.Queries.EntityFramework.BlogPostQueries
{
    public class EfGetBlogPostsQuery : EfUseCase, IGetBlogPostsQuery
    {
        public EfGetBlogPostsQuery(BMContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Get BlogPosts";

        public string Description => "Get BlogPosts using search parameters.";

        public PagedResponse<SearchedBlogPostDTO> Execute(SearchBlogPostsDTO search)
        {
            var query = Context.BlogPosts.Include(x => x.User)
                                         .Include(x => x.BlogPostReactions)
                                         .ThenInclude(x => x.Reaction)
                                         .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Text.Contains(search.Keyword) || x.Title.Contains(search.Keyword));
            }

            if (search.DateFrom != null && search.DateFrom != default(DateTime))
            {
                query = query.Where(x => x.CreatedAt > search.DateFrom);
            }

            if (search.DateTo != null && search.DateTo != default(DateTime))
            {
                query = query.Where(x => x.CreatedAt < search.DateTo);
            }

            var data = query.ToPagedResponse(search, y => new SearchedBlogPostDTO
            {
                Title = y.Title,
                CreatedAt = y.CreatedAt,
                Text = y.Text,
                FullName = Context.Users.Where(x => x.Id == y.UserId).Select(x => x.FirstName).First() + " " + Context.Users.Where(x => x.Id == y.UserId).Select(x => x.LastName).First(),
                Username = Context.Users.Where(x => x.Id == y.UserId).Select(x => x.Username).First(),
                CommentsCount = Context.Comments.Where(x => x.BlogPostId == y.Id).Count(),
                ReactionsCount = Context.BlogPostReactions.Where(x => x.BlogPostId == y.Id).Count()
            });

            return data;

        }
    }
}
