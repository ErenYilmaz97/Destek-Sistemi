using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dto
{
    public class AddDocumentDto
    {
        public IFormFile AddDocument { get; set; }
        public int PetitionID { get; set; }
        
    }
}
