using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedakcniSystem.Data.Models;

namespace RedakcniSystem.Data
{
    public class UsersService
    {
        
        public RoleManager<IdentityRole> RoleManager;
        public UserManager<IdentityUser> UserManager;
        public ApplicationDbContext DbContext { get; set; }

        public UsersService(ApplicationDbContext dbContext,RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            DbContext = dbContext;
            RoleManager = roleManager;
            UserManager = userManager;
            /*roleManager.CreateAsync(new IdentityRole("user"));
            roleManager.CreateAsync(new IdentityRole("admin"));
            roleManager.CreateAsync(new IdentityRole("redactor"));*/
            /*roleManager.CreateAsync(new IdentityRole("redactor"));
            var lol = UserManager.GetUsersInRoleAsync("admin");
            var lol2 = UserManager.GetUsersInRoleAsync("redactor");*/
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

        /*public IdentityRole GetRoleByUserId(int id)
        {
            
        }*/

        public List<IdentityRole> GetRoles()
        {
            return RoleManager.Roles.ToList();
        }

        public void AddNewsletter(string email)
        {
            DbContext.NewsletterEmails.Add(new Email() {EmailAddress = email});
            DbContext.SaveChanges();
        }

        public void RemoveNewsletter(string email)
        {
            foreach (var n in DbContext.NewsletterEmails.Where(note => note.EmailAddress == email).ToArray()) DbContext.Remove(n);
            DbContext.SaveChanges();
        }

        public bool IsUserSubscribed(string email)
        {
            return DbContext.NewsletterEmails.Any(x => x.EmailAddress == email);
        }

        public List<Email> GetAllSubscribed()
        {
            return DbContext.NewsletterEmails.ToList();
        }

        public void SaveChanges(List<Email> emails)
        {
            foreach (var email in emails)
            {
                var temp = DbContext.NewsletterEmails.First(x => x.Id == email.Id);
                DbContext.Entry(temp).CurrentValues.SetValues(email);
            }

            DbContext.SaveChanges();
        }
    }
}