using Microsoft.AspNetCore.Identity;
using Model.Entities.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Contexts.Identity
{
    public class IdentityContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Admin!",
                    UserName = "Admin"

                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
