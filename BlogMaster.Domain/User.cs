using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int ProfilePictureId { get; set; }
        public int RoleId { get; set; }


        public virtual Role Role { get; set; }
        public virtual Image ProfilePicture { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public virtual ICollection<BlogPost> BlogPosts { get; set; } = new HashSet<BlogPost>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<BlogPostReaction> BlogPostReactions { get; set; } = new HashSet<BlogPostReaction>();

    }
}
