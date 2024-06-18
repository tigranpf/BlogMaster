using BlogMaster.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Commands.Users
{
    public interface IEditUserCommand : ICommand<EditUserDTO>
    {
    }
}
