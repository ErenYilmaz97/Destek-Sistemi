using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [DisplayName("Yeni Şifre (Tekrar)")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Şifreler Uyuşmuyor")]
        public string NewPasswordConfirm { get; set; }
    }
}
