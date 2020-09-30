using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Areas.Admin.Models
{
    public class CreateRoleModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Rol Adı")]
        public string RoleName { get; set; }
    }
}
