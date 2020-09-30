using System;
using System.Collections.Generic;
using System.Text;
using AspCoreSupportSystem.Enums;

namespace Entities.Dto
{
    public class ListPetitionsDto
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int PetitionID { get; set; }
        public Statu Statu { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
    }
}
