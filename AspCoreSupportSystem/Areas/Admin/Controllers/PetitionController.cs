using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Controller]
    [Authorize(Roles = "Admin")]
    public class PetitionController : Controller
    {
        private readonly IPetitionService _petitionService;
        private readonly UserManager<User> _userManager;


        //DI
        public PetitionController(IPetitionService petitionService, UserManager<User> userManager)
        {
            _petitionService = petitionService;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("/Admin/Petition")]
        public IActionResult AllPetitions()
        {
            if (TempData["Statu"] != null)
            {
                ViewBag.Statu = TempData["Statu"].ToString();
            }


            var getPetitions = _petitionService.ListAllPetitions();
            return View(getPetitions);
        }



        [HttpGet]
        [Route("/Admin/Petition/Detail/{petitionID:int}")]
        public async Task<IActionResult> Detail(int petitionID)
        {
            if (TempData["PetitionStatu"] != null)
            {
                ViewBag.PetitionStatu = TempData["PetitionStatu"].ToString();
            }

            if (TempData["ContentStatus"] != null)
            {
                ViewBag.ContentStatus = TempData["ContentStatus"].ToString();
            }


            var user = await _userManager.GetUserAsync(User);

            ListPetitionDetailDto PetitionDetail = _petitionService.ListPetitionDetail(petitionID);
            PetitionDetail.Contents.Reverse();

            if (PetitionDetail.Petition == null)
            {
                TempData["Statu"] = "PetitionNotFound";
                return RedirectToAction("AllPetitions");
            }

            PetitionDetail.UserID = user.Id;
            PetitionDetail.isAdmin = User.IsInRole("Admin");

            return View(PetitionDetail);

        }




        [Route("/Admin/Petition/SetPetitionOnProcess/{petitionID:int}")]
        public  IActionResult SetPetitionOnProcess(int petitionID)
        {
            
            var getPetition = _petitionService.GetPetition(petitionID);
            if (getPetition == null)
            {
                TempData["Statu"] = "PetitionNotFound";
                return Redirect($"/Admin/Petition");
            }

            bool result = _petitionService.SetPetitionOnProcess(petitionID);

            if (result)
            {
                TempData["PetitionStatu"] = "PetitionUpdatedOnProcess";
                return Redirect($"/Admin/Petition/Detail/{petitionID}");
            }
            else
            {
                TempData["Statu"] = "Error";
                return Redirect($"/Admin/Petition");
            }
        }





        [Route("/Admin/Petition/SetPetitionToDone/{petitionID:int}")]
        public  IActionResult SetPetitionOnToDone(int petitionID)
        {

            var getPetition = _petitionService.GetPetition(petitionID);
            if (getPetition == null)
            {
                TempData["Statu"] = "PetitionNotFound";
                return Redirect($"/Admin/Petition");
            }

            bool result = _petitionService.SetPetitionToDone(petitionID);

            if (result)
            {
                TempData["PetitionStatu"] = "PetitionUpdatedOnProcess";
                return Redirect($"/Admin/Petition/Detail/{petitionID}");
            }
            else
            {
                TempData["Statu"] = "Error";
                return Redirect($"/Admin/Petition");
            }
        }



        [Route("/Admin/Petition/PetitionNotFound")]
        public IActionResult PetitionNotFound()
        {
            return View();
        }






    }
}
