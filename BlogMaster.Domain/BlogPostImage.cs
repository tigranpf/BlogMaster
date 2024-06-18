using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class BlogPostImage 
    {
        public int BlogPostId { get; set; }
        public int ImageId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual Image Image { get; set; }
    }
}
