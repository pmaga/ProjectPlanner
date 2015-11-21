using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ProjectPlannerASP5.Models.Seeders
{
    public class IdentityContextSeedData
    {
        private readonly UserManager<AppUser> _userManager;

        public IdentityContextSeedData(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("pawel.p.maga@gmail.com") == null)
            {
                var newUser = new AppUser
                {
                    UserName = "pawelmaga",
                    Email = "pawel.p.maga@gmail.com"
                };

                await _userManager.CreateAsync(newUser, "P@ssw0rd");
            }
        }
    }
}
