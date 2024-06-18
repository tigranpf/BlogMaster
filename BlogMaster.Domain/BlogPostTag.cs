using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class BlogPostTag 
    {
        public int BlogPostId { get; set; }
        public int TagId { get; set; }

        public BlogPost BlogPost { get; set; }
        public Tag Tag { get; set; }
    }
}
