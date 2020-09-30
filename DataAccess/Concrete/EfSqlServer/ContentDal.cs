using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Dbcontext;
using Entities.Dto;
using Entities.Entities;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataAccess.Concrete.EfSqlServer
{
    public class ContentDal :IContentDal
    {
        private readonly AppDbContext _context;

        public ContentDal(AppDbContext context)
        {
            _context = context;
        }





        public List<ListContentDto> ListContents(int petitionID)
        {
            List<ListContentDto> result = (from content in _context.Contents
                                join user in _context.Users on content.UserId equals user.Id
                                where content.PetitionID == petitionID
                                orderby content.Date descending 
                                select new ListContentDto()
                                {
                                    Description = content.Description,
                                    Date =  content.Date,
                                    isAdmin = content.isAdmin,
                                    UserName = user.Name +" " + user.Lastname

                                }).ToList();;

            return result;
        }



        public void Add(Content content)
        {
            try
            {
                _context.Add(content);
                _context.SaveChanges();

            }
            catch
            {
                throw new ApplicationException("Bir Hata Oluştu.");
            }
        }



    }
}
