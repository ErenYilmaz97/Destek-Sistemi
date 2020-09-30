using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;

namespace Business.Concrete
{
    public class ContentManager :IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }


        public bool AddContent(Content content)
        {
            try
            {
                _contentDal.Add(content);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool AddContent(ListPetitionDetailDto petitionDetailDto)
        {
            try
            {
                Content content = new Content
                {
                    PetitionID = petitionDetailDto.Petition.PetitionID,
                    Description = petitionDetailDto.AddContent,
                    Date = DateTime.Now,
                    isAdmin = petitionDetailDto.isAdmin,
                    UserId = petitionDetailDto.UserID
                };

                _contentDal.Add(content);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public List<ListContentDto> ListContents(int petitionID)
        {
            try
            {
                var result = _contentDal.ListContents(petitionID);
                return result;
            }
            catch 
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }
    }
}
