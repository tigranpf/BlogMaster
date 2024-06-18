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
    internal class ReactionConfiguration : BaseEntityConfiguration<Reaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(32);

            builder.HasIndex(x => x.Title).IsUnique();

            builder.HasMany(x => x.BlogPostReactions)
                   .WithOne(x => x.Reaction)
                   .HasForeignKey(x => x.ReactionId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
