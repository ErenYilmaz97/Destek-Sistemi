using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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




        [Route("/Admin/Document/{petitionID:int}")]
        public async Task<IActionResult> Documents(int petitionID)
        {
            var user = await _userManager.GetUserAsync(User);
            var getPetition = _petitionService.GetPetition(petitionID);

            if (getPetition == null)
            {
                return Redirect("/Admin/Petition/PetitionNotFound");
            }

            List<Document> documents = _documentService.ListDocuments(petitionID);
            return View(documents);
        }




        [Route("/Admin/Document/Download")]
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

    }
}
