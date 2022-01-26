using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.Entities
{
    public class Role
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
