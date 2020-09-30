using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSupportSystem.Enums;
using Microsoft.AspNetCore.Identity;

namespace AspCoreSupportSystem.CustomValidations
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError(){Code = "DuplicateEmail", Description = "Bu Emailde Bir Kullanıcı Bulunmakta"};
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError(){Code = "PasswordTooShort", Description = $"Şifre En Az {length} Karakter Olmalı."};
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = "DuplicateUserName", Description = "" };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError() { Code = "İnvalidToken", Description = "Geçersiz Link." };
        }
    }
}
