using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspCoreSupportSystem.CustomValidations
{
    public class CustomUserValidations : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> ValidationErrors = new List<IdentityError>();


            if (user.Name.Any(char.IsDigit))
            {
                ValidationErrors.Add(new IdentityError(){Code="NameContainstsDigit", Description = "İsim Bilgisi Sayı İçeremez."});
            }

            if (user.Lastname.Any(char.IsDigit))
            {
                ValidationErrors.Add(new IdentityError(){Code = "LastnameContainsDigit",Description = "Soyisim Bilgisi Sayı İçeremez."});
            }


            if (!ValidationErrors.Any())
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(ValidationErrors.ToArray()));
        }   
    }
}
