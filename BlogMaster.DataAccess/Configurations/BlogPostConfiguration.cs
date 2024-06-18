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
    internal class BlogPostConfiguration : BaseEntityConfiguration<BlogPost>
    {
       protected override void ConfigureEntity(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(3528);
            builder.Property(x => x.UserId).IsRequired();

            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.Text);
            builder.HasIndex(x => x.UserId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.BlogPosts)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comments)
                   .WithOne(x => x.BlogPost)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BlogPostTags)
                   .WithOne(x => x.BlogPost)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.Restrict);         

            builder.HasMany(x => x.BlogPostImages)
                   .WithOne(x => x.BlogPost)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BlogPostReactions)
                   .WithOne(x => x.BlogPost)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
