using System.Linq;

namespace RedakcniSystem.Data
{
    public class PagesService
    {
        private ApplicationDbContext DbContext { get; set; }
        public PagesService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Page GetPage(int id)
        {
            return DbContext.Pages.FirstOrDefault(p => p.Id == id);
        }
        public Page GetPageByName(string name)
        {
            return DbContext.Pages.FirstOrDefault(p => p.Link == name);
        }
        public void AddPage(Page page)
        {
            DbContext.Pages.Add(page);
            DbContext.SaveChanges();
        }
        public void EditPage(Page page)
        {
            var temp = GetPage(page.Id);
            DbContext.Entry(temp).CurrentValues.SetValues(page);
            DbContext.SaveChanges();
        }
    }
}