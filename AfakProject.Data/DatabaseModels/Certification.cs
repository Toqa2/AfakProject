using AfakProject.Data.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfakProject.Data.DatabaseModels
{
    public class Certification : IBaseEntity
    {
        public Certification()
        {
            UserCertifications = new HashSet<UserCertification>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserCertification> UserCertifications { get; set; }
    }
}
