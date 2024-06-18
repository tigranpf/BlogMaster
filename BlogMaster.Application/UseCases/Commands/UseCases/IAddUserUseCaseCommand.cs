using BlogMaster.Application.DTO.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.UseCases
{
    public interface IAddUserUseCaseCommand : ICommand<AddUserUseCaseDTO>
    {
    }
}
