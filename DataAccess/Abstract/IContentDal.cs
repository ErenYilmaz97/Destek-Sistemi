using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dto;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IContentDal
    {
        void Add(Content content);
        List<ListContentDto> ListContents(int petitionID);
    }
}
