using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.Comments
{
    public class CommentDTO
    {
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtHumanized => CreatedAt.Humanize();
        public ICollection<ChildCommentDTO> ChildComments { get; set; } = new List<ChildCommentDTO>();
    }

    public class ChildCommentDTO
    {
        public string Text { get; set; }
    }
}
