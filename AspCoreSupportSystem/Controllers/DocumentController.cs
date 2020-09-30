using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSupportSystem.Enums;
using Business.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Controllers
{
    [Authorize]
    [Controller]
    public class DocumentController : Controller
    {

        private readonly IDocumentService _documentService;
        private readonly IPetitionService _petitionService;
        private readonly UserManager<User> _userManager;




        //DI
        public DocumentController(IDocumentService documentService, IPetitionService petitionService, UserManager<User> userManager)
        {
            _documentService = documentService;
            _petitionService = petitionService;
            _userManager = userManager;
        }



        [HttpGet]
        [Route("~/Documents/{petitionID:int}")]
        public async Task<IActionResult> Documents(int petitionID)
        {
            var user = await _userManager.GetUserAsync(User);
            var getPetition = _petitionService.GetPetition(petitionID);


            if (getPetition == null)
            {
                return RedirectToAction("PetitionNotFound", "Petition");
            }

            if (getPetition.UserID != user.Id)
            {
                return RedirectToAction("PetitionDetailDenied", "Petition");
            }
            

            string documentStatus = string.Empty;

            if (TempData["DocumentStatus"] != null)
            {
                documentStatus = TempData["DocumentStatus"].ToString();
            }

            ViewBag.DocumentStatus = documentStatus;
            ViewBag.petitionStatus = getPetition.Statu;
            ViewBag.petitionID = petitionID;


            List<Document> documents = _documentService.ListDocuments(petitionID);
            return View(documents);
        }





        [HttpGet]
        [Route("~/Document/Add/{petitionID:int}")]
        public async Task<IActionResult> Add(int petitionID)
        {
            var user = await _userManager.GetUserAsync(User);
            var getPetition = _petitionService.GetPetition(petitionID);

            if (getPetition == null)
            {
                return RedirectToAction("Documents");
            }

            if (getPetition.UserID != user.Id)
            {
                return RedirectToAction("PetitionDetailDenied", "Petition");
            }

            if (getPetition.Statu == Statu.Çözüldü)
            {
                TempData["DocumentStatus"] = "PetitionClosed";
                return RedirectToAction("Documents");
            }


            ViewBag.petitionID = petitionID;
            return View();
        }




        [HttpPost]
        [Route("~/Document/Add/{petitionID:int}")]
        public IActionResult Add(AddDocumentDto addDocumentDto)
        {
            if (addDocumentDto.AddDocument == null)
            {
                return RedirectToAction("Documents");
            }


            bool result = _documentService.AddDocument(addDocumentDto);

            if (result)
            {
                TempData["DocumentStatus"] = "DocumentAdded";
                return RedirectToAction("Documents");
            }


            TempData["DocumentStatus"] = "DocumentNotAdded";
            return RedirectToAction("Documents");
        }





        public async Task<IActionResult> Download(string documentName)
        {
            Document getDocument = _documentService.GetDocument(documentName);


            try
            {
                var path = @"C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Documents\" + documentName;

                var memory = new MemoryStream();

                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;

                var ext = Path.GetExtension(path).ToLowerInvariant();
                return File(memory, GetMineTypes()[ext], Path.GetFileName(path));
            }

            catch
            {
                TempData["DocumentStatus"] = "DocumentNotFound";
                return Redirect($"~/Documents/{getDocument.PetitionID}");
            }




        }




        private Dictionary<string, string> GetMineTypes()
        {
            return new Dictionary<string, string>()
            {
                {".txt","text/plain"},
                {".pdf","application/pdf"},
                {".jpg","image/jpeg"},
                {".png","image/png"},
                {".docx","application/vnd.ms-word"}
            };
        }




        public IActionResult DocumentDenied()
        {
            return View();
        }
    }
}
