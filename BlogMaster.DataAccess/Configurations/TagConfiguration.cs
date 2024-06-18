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
    internal class TagConfiguration : BaseEntityConfiguration<Tag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(32);

            builder.HasIndex(x => x.Title).IsUnique();

            builder.HasMany(x => x.BlogPostTags)
                   .WithOne(x => x.Tag)
                   .HasForeignKey(x => x.TagId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
