using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogMaster.Application;
using BlogMaster.Application.DTO.Audit;
using BlogMaster.Application.DTO.Search;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.DataAccess;


namespace BlogMaster.Implementation.UseCases.Queries.EntityFramework.AuditLogs
{
    public class EfGetAuditLogsQuery : EfUseCase, IGetAuditLogsQuery
    {
        private readonly IMapper _mapper;

        public EfGetAuditLogsQuery(BMContext context, IApplicationActor actor, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 12;

        public string Name => "Search UseCase Audit logs";

        public string Description => "Search UseCase Audit logs";

        public IEnumerable<AuditLogDTO> Execute(AuditLogSearchDTO search)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.UseCaseName));
            }

            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.Username.Contains(search.Username));
            }


            if (search.Begin != null)
            {
                query = query.Where(x => x.ExecutedAt > search.Begin);
            }

            if (search.End != null)
            {
                query = query.Where(x => x.ExecutedAt < search.End);
            }

            var results = query.ProjectTo<AuditLogDTO>(_mapper.ConfigurationProvider).ToList();

            return results;
        }
    }
}
