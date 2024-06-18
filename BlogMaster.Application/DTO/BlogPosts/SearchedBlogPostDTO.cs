using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.BlogPosts
{
    public class SearchedBlogPostDTO
    {
        public string Title { get; set; }

        private string _text;

        public string Text
        {
            get => _text;
            set => _text = value.Length <= 50 ? value : value.Substring(0, 47) + "...";
        }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtHumanized => CreatedAt.Humanize();
        public int CommentsCount { get; set; }
        public int ReactionsCount { get; set; }
    }
}
