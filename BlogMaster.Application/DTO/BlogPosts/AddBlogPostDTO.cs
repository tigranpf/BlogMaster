using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.BlogPosts
{
    public class AddBlogPostDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public ICollection<AddBlogPostImageDTO> Images { get; set; } = new List<AddBlogPostImageDTO>();
        public ICollection<AddBlogPostTagDTO> Tags { get; set; } = new List<AddBlogPostTagDTO>();
    }

    public class AddBlogPostImageDTO
    {
        public int Id { get; set; }

    }

    public class AddBlogPostTagDTO
    {
        public int Id { get; set; }

    }
}
