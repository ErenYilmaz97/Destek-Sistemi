using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreSupportSystem.Enums;
using DataAccess.Abstract;
using Entities.Dbcontext;
using Entities.Dto;
using Entities.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataAccess.Concrete.EfSqlServer
{
    public class PetitionDal : IPetitionDal
    {
        private readonly AppDbContext _context;

        public PetitionDal(AppDbContext context)
        {
            _context = context;
        }





        public void Add(Petition petition)
        {
            
                _context.Petitions.Add(petition);
                _context.SaveChanges();

        }



        public List<ListPetitionsDto> ListPetitions(string UserID)
        {
            
                var result =    (from petition in _context.Petitions
                    join user in _context.Users on petition.UserId equals user.Id
                    where petition.UserId == UserID
                    orderby petition.Date descending 
                    select new ListPetitionsDto()
                    {
                        UserName = user.Name +" " + user.Lastname,
                        PetitionID = petition.PetitionID,
                        Statu = (Statu)petition.Statu,
                        Date = petition.Date,
                        Summary = petition.Summary

                    }).ToList();

                return result;

        }



        public ListPetitionsDto GetPetition(int petitionID)
        {
            var result = (from petition in _context.Petitions
                            join user in _context.Users on petition.UserId equals user.Id
                            where petition.PetitionID == petitionID
                            select new ListPetitionsDto()
                            {
                                UserID = user.Id,
                                UserName = user.Name + " " + user.Lastname,
                                PetitionID = petition.PetitionID,
                                Statu = (Statu)petition.Statu,
                                Date = petition.Date,
                                Summary = petition.Summary

                            }).ToList().FirstOrDefault();

            return result;
        }




        public List<ListPetitionsDto> ListAllPetitions()
        {
            var result = (from petition in _context.Petitions
                        join user in _context.Users on petition.UserId equals user.Id
                        orderby petition.Date descending
                          select new ListPetitionsDto()
                        {
                            UserID = user.Id,
                            UserName = user.Name + " " + user.Lastname,
                            PetitionID = petition.PetitionID,
                            Statu = (Statu)petition.Statu,
                            Date = petition.Date,
                            Summary = petition.Summary

                        }).ToList();

            return result;
        }




        public void SetPetitionOnProcess(int petitionID)
        {
            Petition petition = _context.Petitions.Find(petitionID);
            petition.Statu = (int) Statu.İşlemeAlındı;
            _context.SaveChanges();
        }



        public void SetPetitionToDone(int petitionID)
        {
            Petition petition = _context.Petitions.Find(petitionID);
            petition.Statu = (int) Statu.Çözüldü;
            _context.SaveChanges();

        }
    }
}
