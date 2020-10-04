using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IPetitionService _petitionService;

        public UserViewComponent(IPetitionService petitionService)
        {
            _petitionService = petitionService;
        }


        public IViewComponentResult Invoke()
        {
            var PetitionsInfo = _petitionService.GetPetitionInfo();

            return View(PetitionsInfo);
        }
    }
}
