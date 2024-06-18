using BlogMaster.Application.DTO.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.Comments
{
    public interface IAddCommentCommand : ICommand<AddCommentDTO>
    {
    }
}
