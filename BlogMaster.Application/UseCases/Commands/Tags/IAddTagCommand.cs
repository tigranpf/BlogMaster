using BlogMaster.Application.DTO.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.Tags
{
    public interface IAddTagCommand : ICommand<AddTagDTO>
    {
    }
}
