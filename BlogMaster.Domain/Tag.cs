using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<BlogPostTag> BlogPostTags { get; set; } = new HashSet<BlogPostTag>();
    }
}
