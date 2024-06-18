using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMaster.Domain
{
    public class Role : BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<User > Users { get; set; }
        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    }
}
