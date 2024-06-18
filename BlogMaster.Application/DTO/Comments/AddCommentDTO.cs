using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.Comments
{
    public class AddCommentDTO
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public int BlogPostId { get; set; }
        public int? ParentId { get; set; }
    }
}
