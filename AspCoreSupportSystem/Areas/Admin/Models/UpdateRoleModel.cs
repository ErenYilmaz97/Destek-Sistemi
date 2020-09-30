using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;

namespace AspCoreSupportSystem.Areas.Admin.Models
{
    public class UpdateRoleModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Role Adı")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string RoleId { get; set; }
    }
}
