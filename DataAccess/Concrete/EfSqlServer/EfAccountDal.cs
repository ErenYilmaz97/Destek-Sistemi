using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreSupportSystem.Enums;
using DataAccess.Abstract;
using DataAccess.Dto;
using Entities.Dbcontext;
using Entities.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataAccess.Concrete.EfSqlServer
{
    public class EfAccountDal : IAccountDal
    {
        private readonly AppDbContext _context;

        public EfAccountDal(AppDbContext context)
        {
            _context = context;
        }




        public List<UserProfileListDto> GetUserProfile(string id)
        {
            var result = (from user in _context.Users
                join city in _context.Cities on user.CityID equals city.CityID
                where user.Id == id
                select new UserProfileListDto()
                {
                    UserID = user.Id,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    BirthDay = user.BirthDay,
                    Gender = (Gender)user.Gender,
                    CityName = city.CityName,
                    CityID = city.CityID
                }).ToList();

            return result;
        }


        public List<UserProfileListDto> GetUsers()
        {
            var result = (from user in _context.Users
                join city in _context.Cities on user.CityID equals city.CityID
                select new UserProfileListDto()
                {
                    UserID = user.Id,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    BirthDay = user.BirthDay,
                    Gender = (Gender)user.Gender,
                    CityName = city.CityName,
                    CityID = city.CityID
                }).ToList();

            return result;
        }


        public User GetUser(string userID)
        {
            return _context.Users.Find(userID);
        }
    }
}
