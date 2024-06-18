using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public User User { get; set; }
    }
}
