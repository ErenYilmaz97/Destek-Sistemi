using System;
using System.Collections.Generic;
using System.Text;
using AspCoreSupportSystem.Models;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IPetitionService
    {
        bool AddPetition(CreatePetitionDto createPetitionDto);
        List<ListPetitionsDto> ListPetitions(string UserID);
        ListPetitionDetailDto ListPetitionDetail(int petitionID);
        ListPetitionsDto GetPetition(int petitionID);
        List<ListPetitionsDto> ListAllPetitions();
        bool SetPetitionOnProcess(int petitionID);
        bool SetPetitionToDone(int petitionID);
        List<PetitionInfoDto> GetPetitionInfo();
    }
}
