using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifre En Az 4 Karakter Olmalı")]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
