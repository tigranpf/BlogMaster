using BlogMaster.Application.DTO.Audit;
using BlogMaster.Application.DTO.Search;
using System.Collections.Generic;


namespace BlogMaster.Application.UseCases.Queries
{
    public interface IGetAuditLogsQuery : IQuery<IEnumerable<AuditLogDTO>, AuditLogSearchDTO>
    {
    }
}
