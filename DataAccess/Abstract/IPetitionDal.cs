using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dto;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IPetitionDal
    {
        void Add(Petition petition);
        List<ListPetitionsDto> ListPetitions(string UserID);
        ListPetitionsDto GetPetition(int petitionID);
        List<ListPetitionsDto> ListAllPetitions();
        void SetPetitionOnProcess(int petitionID);
        void SetPetitionToDone(int petitionID);
        List<PetitionInfoDto> GetPetitionInfo();
    }
}
