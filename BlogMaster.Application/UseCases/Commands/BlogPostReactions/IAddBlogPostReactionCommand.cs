using BlogMaster.Application.DTO.BlogPostReactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.BlogPostReactions
{
    public interface IAddBlogPostReactionCommand : ICommand<ReactOnBlogDTO>
    {
    }
}
