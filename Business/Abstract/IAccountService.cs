using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Dto;

namespace Business.Abstract
{
    public interface IAccountService
    {
        UserProfileListDto GetUserProfile(string id, string profileStatus = null);
        List<UserProfileListDto> GetUsers();
    }
}
