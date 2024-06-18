using BlogMaster.Application.DTO.Log;
using BlogMaster.Application.DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases.Queries
{
    public interface IGetAuditLogsQuery : IQuery<IEnumerable<AuditLogDTO>, AuditLogSearchDTO>
    {
    }
}
