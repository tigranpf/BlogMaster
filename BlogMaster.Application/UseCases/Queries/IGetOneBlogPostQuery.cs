using BlogMaster.Application.DTO.BlogPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Queries
{  
    public interface IGetOneBlogPostQuery : IQuery<BlogPostDTO, int>
    {
    }
}
