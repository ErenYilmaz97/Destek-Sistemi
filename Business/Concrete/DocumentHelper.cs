using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;


namespace Business.Concrete
{
    public static class DocumentHelper
    {

        public static string AddDocument2(IFormFile document)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Documents", fileName);


            using (var stream = new FileStream(path, FileMode.Create))
            {
                 document.CopyToAsync(stream);

                return fileName;
            }
        }



        public static string AddDocument(IFormFile document)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Documents", uniqueFileName);
            document.CopyTo(new FileStream(path, FileMode.Create));

            return uniqueFileName;
        }


        //public static FileStreamResult
    } 

    }

