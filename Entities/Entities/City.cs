using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;

namespace Entities.Entities
{
    public class City : IEntity
    {
        [Key] 
        public int CityID { get; set; }
        public string CityName { get; set; }


        public List<User> Users { get; set; } //BİR ŞEHİRDE BİRDEN ÇOK USER

    }
}
