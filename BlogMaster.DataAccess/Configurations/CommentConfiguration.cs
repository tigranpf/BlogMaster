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
    internal class CommentConfiguration : BaseEntityConfiguration<Comment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(2424);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BlogPostId).IsRequired();
            
            builder.HasIndex(x => x.Text);
            builder.HasIndex(x => x.UserId);
            
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BlogPost)
                   .WithMany(x => x.Comments)
                   .HasForeignKey(x => x.BlogPostId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Children)
                   .WithOne(x => x.Parent)
                   .HasForeignKey(x => x.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
