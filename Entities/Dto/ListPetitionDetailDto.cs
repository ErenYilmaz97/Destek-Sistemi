using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class ListPetitionDetailDto
    {
        public ListPetitionsDto Petition { get; set; }
        public List<ListContentDto> Contents { get; set; }


        //DETAY SAYFASINDA, KULLANICI YORUM DA YAZABİLİR.
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(20,ErrorMessage = "En Az 20 Karakter")]
        [DisplayName("Yorum Ekle")]
        public string AddContent { get; set; }


        public string UserID { get; set; }
        public bool isAdmin { get; set; }
    }
}
