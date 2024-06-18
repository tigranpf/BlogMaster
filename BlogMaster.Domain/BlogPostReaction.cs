using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class BlogPostReaction 
    {
        public int BlogPostId { get; set; }
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public DateTime ReactedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public User User { get; set; }
        public BlogPost BlogPost { get; set; }
        public Reaction Reaction { get; set; }
    }
}
