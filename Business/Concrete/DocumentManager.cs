using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private readonly IHostingEnvironment _hostingEnvironment;


        //DI
        public DocumentManager(IDocumentDal documentDal, IHostingEnvironment enviroment)
        {
            _documentDal = documentDal;
            _hostingEnvironment = enviroment;
        }



        public bool AddDocument(AddDocumentDto addDocumentDto)
        {
            try
            {
                string uniqueFileName = DocumentHelper.AddDocument(addDocumentDto.AddDocument);


                Document document = new Document()
                {
                    PetitionID = addDocumentDto.PetitionID,
                    FileName = addDocumentDto.AddDocument.FileName,
                    DocumentName = uniqueFileName
                };


                bool result = _documentDal.Add(document);
                return result;
            }

            catch
            {
                return false;
            }
        }



        public List<Document> ListDocuments(int petitionID)
        {
            try
            {
                return _documentDal.ListDocuments(petitionID);
            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu.");
            }
        }



        public Document GetDocument(string documentName)
        {
            return _documentDal.GetDocument(documentName);
        }

    }
}