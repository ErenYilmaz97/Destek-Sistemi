using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspCoreSupportSystem.Enums;
using AspCoreSupportSystem.Models;
using AspNetCoreIdentity.PRG;
using Business.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Controllers
{
    [Authorize]
    public class PetitionController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IPetitionService _petitionService;
        private readonly SignInManager<User> _signInManager;


        //DI
        public PetitionController(UserManager<User> userManager, IPetitionService petitionService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _petitionService = petitionService;
            _signInManager = signInManager;
        }





        [Route("/Petitions")]
        public async Task<IActionResult> Index()
        {
            string petitionStatus = string.Empty;

            if (TempData["PetitionStatus"] != null)
            {
                petitionStatus = TempData["PetitionStatus"].ToString();
            }

            ViewBag.PEtitionStatus = petitionStatus;



            var user = await _userManager.GetUserAsync(User);

            var listPetitionsDto = _petitionService.ListPetitions(user.Id);

            return View(listPetitionsDto);
        }




        [Route("~/MainPage")]
        public IActionResult MainPage()
        {
            return View();
        }





        [ImportModelState]
        [HttpGet]
        [Route("/Petition/CreatePetition")]
        public async Task<IActionResult> CreatePetition()
        {

            var user = await _userManager.GetUserAsync(User);

            var isExistPetition = _petitionService.ListPetitions(user.Id).Count(x => x.Statu == Statu.Gönderildi || x.Statu == Statu.İşlemeAlındı);

            if (isExistPetition != 0)
            {
                TempData["PetitionStatus"] = "ThereIsUnsolvedPetition";
                return Redirect("/Petitions");
            }
            CreatePetitionDto createPetitionDto = new CreatePetitionDto()
            {
                UserID = user.Id,
                isAdmin = User.IsInRole("Admin"),
                Email = user.Email
            };

            return View(createPetitionDto);
        }




        [HttpPost]
        [ExportModelState]
        [Route("/Petition/CreatePetition")]
        public async Task<IActionResult> CreatePetition(CreatePetitionDto createPetitionDto)
        {
            //MODEL VALİD Mİ
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreatePetition");
            }

            var user = await _userManager.GetUserAsync(User);


            bool result = _petitionService.AddPetition(createPetitionDto);

            if (result)
            {
                TempData["PetitionStatus"] = "PetitionCreated";
                return Redirect("/Petitions");
            }
            else
            {
                TempData["PetitionStatus"] = "PetitionNotCreated";
                return Redirect("/Petitions");
            }
        }






        [HttpGet]
        [Route("~/Petition/Detail/{petitionID:int}")]
        
        public async Task<IActionResult> Detail(int petitionID)
        {
            ViewBag.petitionID = petitionID;


            string contentStatus = string.Empty;

            if (TempData["ContentStatus"] != null)
            {
                contentStatus = TempData["ContentStatus"].ToString();
            }

            ViewBag.ContentSTatus = contentStatus;


            var user = await _userManager.GetUserAsync(User);



            ListPetitionDetailDto PetitionDetailDto = _petitionService.ListPetitionDetail(petitionID);
            PetitionDetailDto.Contents.Reverse();
            


            //NULL KONTROLÜ
            if (PetitionDetailDto.Petition == null)
            {
                return RedirectToAction("PetitionNotFound");
            }


            //NULL DEĞİL, LOGİN DURUMDAKİ KULLANICIYA AİT BİR DİLEKÇE Mİ?
            if (PetitionDetailDto.Petition.UserID != user.Id)
            {
                return RedirectToAction("PetitionDetailDenied");
            }


            PetitionDetailDto.UserID = user.Id;
            PetitionDetailDto.isAdmin = User.IsInRole("Admin");

            return View(PetitionDetailDto);
        }




      
        public IActionResult PetitionNotFound()
        {
            return View();
        }





        public IActionResult PetitionDetailDenied()
        {
            return View();
        }


        
        
    }
}
