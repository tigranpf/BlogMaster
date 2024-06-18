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
    public class BlogPostReactionConfiguration : IEntityTypeConfiguration<BlogPostReaction>
    {
        public void Configure(EntityTypeBuilder<BlogPostReaction> builder)
        {
            builder.Property(x => x.ReactedAt).HasDefaultValueSql("GETDATE()");

            builder.HasKey(x => new { x.ReactionId, x.BlogPostId, x.UserId });
        }
    }
}
