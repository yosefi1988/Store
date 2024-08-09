using Microsoft.AspNetCore.Identity;

namespace WebApplicationStore.Controllers.Classroom
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
