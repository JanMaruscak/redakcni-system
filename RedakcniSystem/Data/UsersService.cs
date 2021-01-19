using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RedakcniSystem.Data
{
    public class UsersService
    {
        
        public RoleManager<IdentityRole> RoleManager;
        public UserManager<IdentityUser> UserManager;

        public UsersService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            /*roleManager.CreateAsync(new IdentityRole("user"));
            roleManager.CreateAsync(new IdentityRole("admin"));
            roleManager.CreateAsync(new IdentityRole("redactor"));*/
            roleManager.CreateAsync(new IdentityRole("redactor"));
            var lol = UserManager.GetUsersInRoleAsync("admin");
            var lol2 = UserManager.GetUsersInRoleAsync("redactor");
        }

        public async Task AddAdmin(string email)
        {
            var user = UserManager.FindByEmailAsync(email).Result;
            await UserManager.AddToRoleAsync(user, "admin");
        }
        public async Task AddRedactor(string email)
        {
            var user = UserManager.FindByEmailAsync(email).Result;
            await UserManager.AddToRoleAsync(user, "redactor");
        }
    }
}