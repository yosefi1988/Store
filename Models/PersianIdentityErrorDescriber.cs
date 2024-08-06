using Microsoft.CodeAnalysis.Editing;
using Microsoft.AspNetCore.Identity;


namespace WebApplicationStore.Models
{
    public class PersianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return base.DuplicateEmail(email);
        }
        public override IdentityError InvalidEmail(string email)
            => new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = $"ایمیل '{email}' یک ایمیل معتبر نیست.",
            };
    }
} 
