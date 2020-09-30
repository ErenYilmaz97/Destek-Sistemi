using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspCoreSupportSystem.CustomValidations
{
    public class CustomPasswordValidations : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> ValidationErrors = new List<IdentityError>();

            if (password.ToLower().Contains(user.Name.ToLower()))
            {
                ValidationErrors.Add(new IdentityError(){Code = "PasswordContainsName", Description = "Şifre İsminizi İçeremez."});
            }

            if (password.ToLower().Contains(user.Lastname.ToLower()))
            {
                ValidationErrors.Add(new IdentityError(){Code = "PasswordContainsLastname", Description = "Şifre Soyadınızı İçeremez."});
            }

            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                ValidationErrors.Add(new IdentityError{Code = "PasswordContainsEmail", Description = "Şifre Mailinizi İçeremez."});
            }

            if (password.Contains("1234"))
            {
                ValidationErrors.Add(new IdentityError(){Code = "PasswordisSuccessive", Description = "Şifre Ardışık Sayılardan Oluşamaz."});
            }


            if (!ValidationErrors.Any())
                return Task.FromResult(IdentityResult.Success);

            else
                return Task.FromResult(IdentityResult.Failed(ValidationErrors.ToArray()));
        }
    }
}
