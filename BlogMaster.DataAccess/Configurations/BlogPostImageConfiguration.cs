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
    public class BlogPostImageConfiguration : IEntityTypeConfiguration<BlogPostImage>
    {
        public void Configure(EntityTypeBuilder<BlogPostImage> builder)
        {
            builder.HasKey(x => new { x.BlogPostId, x.ImageId });
        }
    }
}
