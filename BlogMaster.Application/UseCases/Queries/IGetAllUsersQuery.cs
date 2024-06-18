using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Queries
{
    public interface IGetAllUsersQuery : IQuery<IEnumerable<UserDTO>, SearchUsersDTO>
    {
    }
}
