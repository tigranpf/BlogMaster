using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.BlogPosts
{
    public class EditBlogPostDTO : AddBlogPostDTO
    {
        public int Id { get; set; }
    }
}
