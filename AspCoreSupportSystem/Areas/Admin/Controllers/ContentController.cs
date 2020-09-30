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
    [Authorize(Roles = "Admin")]
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


            bool result = _contentService.AddContent(petitionDetailDto);


            if (result)
            {
                TempData["ContentStatus"] = "ContentAdded";
                return Redirect($"/Admin/Petition/Detail/{petitionDetailDto.Petition.PetitionID}");
            }
            else
            {
                TempData["ContentStatus"] = "ContentNotAdded";
                return Redirect($"/Admin/Petition/Detail/{petitionDetailDto.Petition.PetitionID}");
            }

        }
    }
}

