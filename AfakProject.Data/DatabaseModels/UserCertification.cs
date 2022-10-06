using AfakProject.Data.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfakProject.Data.DatabaseModels
{
    public class UserCertification : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CertificationId { get; set; }
        public virtual Certification Certification { get; set; }
    }
}
