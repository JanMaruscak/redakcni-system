using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RedakcniSystem.Data
{
    public class MenuService
    {
        public ApplicationDbContext DbContext { get; set; }
        public MenuService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<Menu> GetMenus()
        {
            var menus = DbContext.Menus.Include(m => m.Buttons).ToList();
            return menus;
        }
        public Menu GetMenu(int id)
        {
            return DbContext.Menus.Include(m => m.Buttons).FirstOrDefault((a) => a.Id == id);
        }
        public Menu GetMenuByRoleId(string id)
        {
            return DbContext.Menus.Include(m => m.Buttons).FirstOrDefault((a) => a.Role == id);
        }

        public void AddMenu(Menu menu)
        {
            DbContext.Menus.Add(menu);
            DbContext.SaveChanges();
        }
        public void EditMenu(Menu menu)
        {
            var temp = GetMenu(menu.Id);
            DbContext.Entry(temp).CurrentValues.SetValues(menu);
            DbContext.SaveChanges();
        }
    }
}