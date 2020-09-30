using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;

namespace AspCoreSupportSystem.Models
{
    public class SignUpModel
    {
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(2,ErrorMessage = "İsim En Az 3 Harften Oluşmalı")]
        [MaxLength(25,ErrorMessage = "İsim En Fazla 25 Harften Oluşmalı")]
        public string Name { get; set; }

        [DisplayName("Soy İsim")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(2, ErrorMessage = "Soyisim En Az 2 Harften Oluşmalı")]
        [MaxLength(25, ErrorMessage = "Soyisim En Fazla 25 Harften Oluşmalı")]
        public string LastName { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(4,ErrorMessage = "Şifre En Az 4 Karakter Olmalı")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre (Tekrar)")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Şehir")]
        public int SelectedCityID { get; set; }

        public List<City> Cities { get; set; }
    }
}
