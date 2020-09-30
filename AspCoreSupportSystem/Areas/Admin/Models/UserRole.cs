using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Areas.Admin.Models
{
    public class UserRole
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Exist { get; set; }
        public bool NewValue { get; set; }


    }
}
