using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int CityID { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Gender { get; set; }


        public City City { get; set; } //BİR USERIN BİR ŞEHRİ
        public List<Petition> Petitions { get; set; }  //BİR USERİN BİRDEN ÇOK DİLEKÇESİ
        public List<Content> Contents { get; set; }  //BİR ADMİNİN CEVAPLADIĞI BİRDEN ÇOK DETAY
    }
}
