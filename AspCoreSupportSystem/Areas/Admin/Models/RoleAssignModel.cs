using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Areas.Admin.Models
{
    public class RoleAssignModel
    {
        public RoleAssignModel()
        {
            UserRoles = new List<UserRole>();
        }


        public string NameLastname { get; set; }
        public string UserID { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
