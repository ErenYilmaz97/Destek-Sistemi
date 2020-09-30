using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Dto;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {

        private readonly IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }


        public UserProfileListDto GetUserProfile(string id,string profileStatus)
        {
             UserProfileListDto userProfile = _accountDal.GetUserProfile(id).FirstOrDefault();

             //DURUM KONTROLÜ
             if (profileStatus != null)
             {
                 userProfile.ProfileStatus = profileStatus;
                 
             }

             return userProfile;
        }


        public List<UserProfileListDto> GetUsers()
        {
            return _accountDal.GetUsers();
        }
    }
}
