using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.Search
{
    public class AuditLogSearchDTO
    {
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public string? UseCaseName { get; set; }
        public string? Username { get; set; }
        public bool? IsAuthorized { get; set; }
    }
}
