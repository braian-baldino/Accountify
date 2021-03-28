using Microsoft.AspNetCore.Identity;

namespace Model.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
