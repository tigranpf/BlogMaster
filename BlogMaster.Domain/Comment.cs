using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public int BlogPostId { get; set; }
        public int? ParentId { get; set; }

        public virtual User User { get; set; }
        public virtual BlogPost BlogPost { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; set; } = new HashSet<Comment>();
    }
}
