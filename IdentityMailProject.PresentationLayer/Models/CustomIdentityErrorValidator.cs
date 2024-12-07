using Microsoft.AspNetCore.Identity;

namespace IdentityMailProject.PresentationLayer.Models
{
    public class CustomIdentityErrorValidator : IdentityErrorDescriber
    {

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = "Bu Email Adresi Sistemde Zaten Kayıtlı!"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DuplicateUserName",
                Description = $"'{userName}' kullanıcı adı zaten alınmış!"
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = "InvalidEmail",
                Description = $"'{email}' geçerli bir email adresi değil!"
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = $"'{userName}' geçerli bir kullanıcı adı değil!"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır!"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifre en az bir sembol içermelidir (!, @, #, vb.)"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifre en az bir rakam (0-9) içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Şifre en az bir küçük harf (a-z) içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifre en az bir büyük harf (A-Z) içermelidir!"
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = "UserAlreadyHasPassword",
                Description = "Kullanıcı zaten bir şifreye sahip!"
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = "UserLockoutNotEnabled",
                Description = "Bu kullanıcı için hesap kilitleme aktif değil!"
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = "UserNotInRole",
                Description = $"Kullanıcı '{role}' rolünde değil!"
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = "UserAlreadyInRole",
                Description = $"Kullanıcı zaten '{role}' rolünde!"
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = "InvalidRoleName",
                Description = $"'{role}' geçerli bir rol adı değil!"
            };
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code = "ConcurrencyFailure",
                Description = "Eşzamanlılık hatası oluştu. Lütfen işlemi tekrar deneyin."
            };
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = "DefaultError",
                Description = "Bir hata oluştu. Lütfen tekrar deneyin."
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Code = "RecoveryCodeRedemptionFailed",
                Description = "Kurtarma kodu geçersiz!"
            };
        }
    }


}

