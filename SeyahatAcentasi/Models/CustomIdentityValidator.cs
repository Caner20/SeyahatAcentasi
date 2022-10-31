using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length) //parola cok kisa
        {
            return new IdentityError() //geriye IdentityError dan hata degeri dondur
            {
                Code = "PasswordTooShort",  
                Description = $"Parola Minimum {length} karakter olmalıdır"  //parola lenght ten gelen karakter degeri kadar olmalidir
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola en az 1 büyük harf içermelidir"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az 1 küçük harf içermelidir"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az 1 sembol içermelidir"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Parola en az 1  '0'-'9' arası  karakter içermelidir "
            };
        }
    }
}
