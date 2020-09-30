using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspCoreSupportSystem.Enums;
using Entities.Entities;

namespace DataAccess.Dto
{
    public class UserProfileListDto
    {
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(2, ErrorMessage = "İsim En Az 3 Harften Oluşmalı")]
        [MaxLength(25, ErrorMessage = "İsim En Fazla 25 Harften Oluşmalı")]
        public string Name { get; set; }


        [DisplayName("Soy İsim")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(2, ErrorMessage = "Soyisim En Az 2 Harften Oluşmalı")]
        [MaxLength(25, ErrorMessage = "Soyisim En Fazla 25 Harften Oluşmalı")]
        public string Lastname { get; set; }


        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Şehir")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Cinsiyet")]
        public Gender Gender { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }


        [Required(ErrorMessage = "Zorunlu Alan")]
        public int CityID { get; set; }
        public List<City> Cities { get; set; }

        public string UserID { get; set; }

        public string ProfileStatus { get; set; }
        



    }
}
