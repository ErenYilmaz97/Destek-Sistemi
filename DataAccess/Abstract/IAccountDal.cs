using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Dto;
using Entities.Entities;

namespace DataAccess.Abstract
{
   public interface IAccountDal
   {
       List<UserProfileListDto> GetUserProfile(string id);
       List<UserProfileListDto> GetUsers();
       User GetUser(string userID);
   }
}
