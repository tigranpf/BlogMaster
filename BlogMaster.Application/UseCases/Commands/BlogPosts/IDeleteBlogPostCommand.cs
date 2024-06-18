using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.BlogPosts
{
    public interface IDeleteBlogPostCommand : ICommand<int>
    {
    }
}
