using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class Reaction : BaseEntity
    {
        public string Title { get; set; }
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual ICollection<BlogPostReaction> BlogPostReactions { get; set; } = new HashSet<BlogPostReaction>();
    }
}
