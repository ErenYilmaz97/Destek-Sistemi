using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dto;
using Entities.Entities;

namespace Business.Abstract
{
    public interface IContentService
    {
        bool AddContent(Content content);
        List<ListContentDto> ListContents(int petitionID);
        bool AddContent(ListPetitionDetailDto petitionDetailDto);
    }
}
