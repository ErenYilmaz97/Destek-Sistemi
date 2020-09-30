using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Entities
{
    public class Content : IEntity
    {
        [Key] 
        public int ContentID { get; set; }
        public int PetitionID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool isAdmin { get; set; }
        public string UserId { get; set; }

        public Petition Petition { get; set; }  //BİR DETAY BİR DİLEKÇEYE AİT
        public User User { get; set; }          //BİR DETAYI BİR ADMİN CEVAPLAYABİLİR
    }
}
