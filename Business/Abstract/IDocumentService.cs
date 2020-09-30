using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IDocumentService
    {
        bool AddDocument(AddDocumentDto addDocumentDto);
        List<Document> ListDocuments(int petitionID);
        Document GetDocument(string documentName);
    }
}
