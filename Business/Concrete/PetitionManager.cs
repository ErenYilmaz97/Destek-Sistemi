using System;
using System.Collections.Generic;
using System.Text;
using AspCoreSupportSystem.Enums;
using AspCoreSupportSystem.Models;
using AspNetCoreIdentity.SMTP;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;

namespace Business.Concrete
{
    public class PetitionManager : IPetitionService
    {

        private readonly IPetitionDal _petitionDal;
        private readonly IAccountDal _accountDal;
        private readonly IContentService _contentService;


        public PetitionManager(IPetitionDal petitionDal, IContentService contentService, IAccountDal accountDal)
        {
            _petitionDal = petitionDal;
            _contentService = contentService;
            _accountDal = accountDal;
        }



        public bool AddPetition(CreatePetitionDto createPetitionDto)
        {
            try
            {
                Petition newPetition = new Petition()
                {
                    Summary = createPetitionDto.Summary,
                    Statu = (int)Statu.Gönderildi,
                    //MEVCUT LOGİN KULLANICI ÜZERİNE OLUŞTUR
                    UserId = createPetitionDto.UserID,
                    Date = DateTime.Now
                };


                _petitionDal.Add(newPetition);


                Content newContent = new Content()
                {
                    PetitionID = newPetition.PetitionID,
                    Description = createPetitionDto.FirstComment,
                    Date = DateTime.Now,
                    UserId = createPetitionDto.UserID,
                };

               bool result = _contentService.AddContent(newContent);
               MailHelper.SendPetitionCreated(newPetition,createPetitionDto.Email);
                
                return result;
            }

            catch
            {
                return false;
            }

        }



        public List<ListPetitionsDto> ListPetitions(string UserID)
        {
            try
            {
                return _petitionDal.ListPetitions(UserID);
            }
            catch 
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }


        public ListPetitionsDto GetPetition(int petitionID)
        {
            return _petitionDal.GetPetition(petitionID);
        }



        public ListPetitionDetailDto ListPetitionDetail(int petitionID)
        {
            try
            {
                ListPetitionDetailDto PetitionDetailDto = new ListPetitionDetailDto()
                {
                    Petition = _petitionDal.GetPetition(petitionID),
                    Contents = _contentService.ListContents(petitionID)
                };

                return PetitionDetailDto;
            }
            catch 
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }



        public List<ListPetitionsDto> ListAllPetitions()
        {
            try
            {
                return _petitionDal.ListAllPetitions();
            }
            catch 
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }



        public bool SetPetitionOnProcess(int petitionID)
        {
            try
            {

                _petitionDal.SetPetitionOnProcess(petitionID);
                var petition = _petitionDal.GetPetition(petitionID);

                User user = _accountDal.GetUser(petition.UserID);
                MailHelper.SendPetitionOnProcess(petition,user.Email);
                return true;

            }
            catch
            {
                return false;
            }
        }




        public bool SetPetitionToDone(int petitionID)
        {
            try
            {
                _petitionDal.SetPetitionToDone(petitionID);
                var petition = _petitionDal.GetPetition(petitionID);

                User user = _accountDal.GetUser(petition.UserID); 
                MailHelper.SendPetitionToDone(petition,user.Email);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public List<PetitionInfoDto> GetPetitionInfo()
        {
            return _petitionDal.GetPetitionInfo();
        }
    }
}
