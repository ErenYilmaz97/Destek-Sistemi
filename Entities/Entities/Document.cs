using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Entities
{
    public class Document : IEntity
    {
        [Key] public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string FileName { get; set; }
        public int PetitionID { get; set; }

        public Petition Petition { get; set; }  //BİR DÖKÜMAN BİR DİLEKÇEYE AİT
    }
}
