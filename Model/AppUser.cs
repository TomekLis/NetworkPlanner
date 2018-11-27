using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Model
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Plans = new HashSet<Plan>();
        }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
