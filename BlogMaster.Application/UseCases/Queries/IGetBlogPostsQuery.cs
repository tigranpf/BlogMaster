using BlogMaster.Application.DTO.BlogPosts;
using BlogMaster.Application.DTO.Pagination;
using BlogMaster.Application.DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Queries
{
    public interface IGetBlogPostsQuery : IQuery<PagedResponse<SearchedBlogPostDTO>,SearchBlogPostsDTO>
    {
    }
}
