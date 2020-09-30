using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Models
{
    public class ChangePasswordModel
    {

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }



        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Yeni Şifre")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifre En Az 4 Karakter Olmalı.")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Yeni Şifre (Tekrar)")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string NewPasswordConfirm { get; set; }
    }
}
