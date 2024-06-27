using AutoMapper;
using BlogMaster.Application.DTO.Audit;
using BlogMaster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.Profiles
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<UseCaseLog, AuditLogDTO>();
        }
    }
}
