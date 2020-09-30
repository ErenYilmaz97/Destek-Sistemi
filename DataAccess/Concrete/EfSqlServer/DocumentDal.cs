using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Dbcontext;
using Entities.Entities;

namespace DataAccess.Concrete.EfSqlServer
{
    public class DocumentDal : IDocumentDal
    {
        private readonly AppDbContext _context;

        public DocumentDal(AppDbContext context)
        {
            _context = context;
        }



        public bool Add(Document document)
        {
            try
            {
                _context.Add(document);
                _context.SaveChanges();
                return true;
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
                return _context.Documents.Where(x => x.PetitionID == petitionID).ToList();
            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu");
            }
        }


        public Document GetDocument(string documentName)
        {
            return _context.Documents.Where(x => x.DocumentName == documentName).FirstOrDefault();
        }
    }


}
