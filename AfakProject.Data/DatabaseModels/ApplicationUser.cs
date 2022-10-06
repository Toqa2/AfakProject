using AfakProject.Data.GenericModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfakProject.Data.DatabaseModels
{
    public class ApplicationUser : IdentityUser, IBaseEntity
    {
        public ApplicationUser()
        {
            UserCertifications = new HashSet<UserCertification>();  
        }
        public string Name { get; set; }
        public virtual ICollection<UserCertification> UserCertifications { get; set; }
    }
}
