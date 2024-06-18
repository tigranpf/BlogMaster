using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.DTO.Users
{
    public class EditUserDTO
    {
        public int UserId { get; set; }              
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public string Password { get; set; }
        public int? ProfilePictureId { get; set; }
        public string Username { get; set; }
        public List<int> UserUseCases { get; set; }  
    }
}
