using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSupportSystem.Models
{
    public class CreatePetitionDto
    {
        public string UserID { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(10,ErrorMessage = "Başlık En Az 10 Karakter Olmalı.")]
        [DisplayName("Başlık")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DisplayName("Açıklama")]
        [MinLength(20, ErrorMessage = "Lütfen Sorununuzu Daha Açıklayıcı Şekilde Anlatınız. (En Az 20 Karakter)")]
        public string FirstComment { get; set; }


        public bool isAdmin { get; set; }
        public string Email { get; set; }

    }
}
