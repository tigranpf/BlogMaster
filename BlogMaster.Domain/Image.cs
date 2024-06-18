using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class Image : BaseEntity
      {
        public string Path { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BlogPostImage> BlogPostImages { get; set; } = new HashSet<BlogPostImage>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
