using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Entities
{
    public class Petition : IEntity
    {
        [Key] 
        public int PetitionID { get; set; }
        public string Summary { get; set; }
        public string UserId { get; set; }
        public int Statu { get; set; }
        public DateTime Date { get; set; }


        public User User { get; set; }  //BİR DİLEKÇENİN BİR USERİ
        public List<Document> Documents { get; set; }  //BİR DİLEKÇENİN BİRDEN ÇOK DÖKÜMANI
        public List<Content> Contents { get; set; }  //BİR DİLEKÇENİN BİRDEN ÇOK DETAYI

    }
}
