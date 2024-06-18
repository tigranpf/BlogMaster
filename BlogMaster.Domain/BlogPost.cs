using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BlogPostTag> BlogPostTags { get; set; } = new HashSet<BlogPostTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<BlogPostImage> BlogPostImages { get; set; } = new HashSet<BlogPostImage>();
        public virtual ICollection<BlogPostReaction> BlogPostReactions { get; set; } = new HashSet<BlogPostReaction>();
    }
}
