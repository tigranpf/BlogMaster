using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogMaster.Application;
using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.DTO.Users;
using BlogMaster.Application.Exceptions;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases.Queries.EntityFramework.Users
{
    public class EfGetAllUsersQuery : EfUseCase, IGetAllUsersQuery
    {
        private readonly IMapper _mapper;

        public EfGetAllUsersQuery(BMContext context, IApplicationActor actor, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Get all registered users";

        public string Description => "Admin gets info about all registered users";

        public IEnumerable<UserDTO> Execute(SearchUsersDTO search)
        {
            try
            {
                var query = Context.Users
                    .Include(x => x.Role) 
                    .Include(x => x.UserUseCases) 
                    .AsQueryable();

                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    string keywordLower = search.Keyword.ToLower();
                    query = query.Where(x =>
                        x.FirstName.ToLower().Contains(keywordLower) ||
                        x.LastName.ToLower().Contains(keywordLower) ||
                        x.Email.ToLower().Contains(keywordLower) 
                    );
                }

                if (search.IsActive != null)
                {
                    query = query.Where(x => x.IsActive == search.IsActive);
                }

                if (search.UseCaseId != null)
                {
                    query = query.Where(x => x.UserUseCases.Any(y => y.UseCaseId == search.UseCaseId));
                }

                var result = query.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToList();

                return result;
            }
            catch (Exception e)
            {
                throw new ConflictException("Error occurred while fetching users.");
            }
        }
    }
}
