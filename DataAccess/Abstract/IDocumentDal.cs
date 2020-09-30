using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IDocumentDal
    {
        bool Add(Document document);
        List<Document> ListDocuments(int petitionID);
        Document GetDocument(string documentName);
    }
}
