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
    internal class ImageConfiguration : BaseEntityConfiguration<Image>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(248);
            builder.Property(x => x.Description).IsRequired();

            builder.HasIndex(x => x.Path).IsUnique();

            builder.HasMany(x => x.BlogPostImages)
                   .WithOne(x => x.Image)
                   .HasForeignKey(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Users)
                   .WithOne(x => x.ProfilePicture)
                   .HasForeignKey(x => x.ProfilePictureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
