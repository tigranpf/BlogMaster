using BlogMaster.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.DataAccess.Configurations
{
    public class RoleUseCaseConfiguration : IEntityTypeConfiguration<RoleUseCase>
    {
        public void Configure(EntityTypeBuilder<RoleUseCase> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.UseCaseId });
        }
    }
}
