using BlogMaster.Domain;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.BlogPosts
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentsCount { get; set; }
        public int ReactionsCount { get; set; }
        public ICollection<BlogPostImageDTO> Images { get; set; } = new List<BlogPostImageDTO>();
        public ICollection<BlogPostTagDTO> Tags { get; set; } = new List<BlogPostTagDTO>();
        public ICollection<BlogPostCommentDTO> Comments { get; set; } = new List<BlogPostCommentDTO>();
        public ICollection<BlogPostReactionDTO> Reactions { get; set; } = new List<BlogPostReactionDTO>();
    }

    public class BlogPostCommentDTO
    {
        public string Username { get; set; }
        public string UserProfilePicture { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
    }

    public class BlogPostReactionDTO
    {
        public string Reaction { get; set; } 
        public string Username { get; set;}      
    }

    public class BlogPostImageDTO
    {
        public string Path { get; set; }
        public string Description { get; set; }
    }

    public class BlogPostTagDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

}
