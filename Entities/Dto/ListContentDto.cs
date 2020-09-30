using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ListContentDto
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool isAdmin { get; set; }
        public string UserName { get; set; }
    }
}
