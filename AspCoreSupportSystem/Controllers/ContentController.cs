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

namespace AspCoreSupportSystem.Controllers
{
    [Authorize]
    [Controller]
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly UserManager<User> _userManager;


        //DI
        public ContentController(IContentService contentService, UserManager<User> userManager)
        {
            _contentService = contentService;
            _userManager = userManager;
        }



        [HttpPost]
        public IActionResult AddContent(ListPetitionDetailDto petitionDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Detail", "Petition");
            }


            var checkContents = _contentService.ListContents(petitionDetailDto.Petition.PetitionID).Take(2).ToList();

            //SPAM KONTROLÜ
            if (checkContents.Count(x => x.isAdmin == false) == 2)
            {
                TempData["ContentStatus"] = "ContentSpam";
                return Redirect($"~/Petition/Detail/{petitionDetailDto.Petition.PetitionID}");
            }

            

            bool result = _contentService.AddContent(petitionDetailDto);



            if (result)
            {
                TempData["ContentStatus"] = "ContentAdded";
                return Redirect($"~/Petition/Detail/{petitionDetailDto.Petition.PetitionID}");
            }
            else
            {
                TempData["ContentStatus"] = "ContentNotAdded";
                return Redirect($"~/Petition/Detail/{petitionDetailDto.Petition.PetitionID}");
            }

        }


        [HttpGet]
        public IActionResult Deneme()
        {
            return View();
        }
    }
}