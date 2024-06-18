using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.UseCases
{
    public class DeleteUserUseCaseDTO
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }
}
