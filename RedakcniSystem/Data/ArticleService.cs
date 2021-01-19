using System.Collections.Generic;
using System.Linq;

namespace RedakcniSystem.Data
{
    public class ArticleService
    {
        public ApplicationDbContext DbContext { get; set; }

        public ArticleService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Article> GetArticles()
        {
            return DbContext.Articles.ToList();
        }
        public Article GetArticle(int id)
        {
            return DbContext.Articles.FirstOrDefault((a) => a.Id == id);
        }

        public void EditArticle(Article article)
        {
            var temp = GetArticle(article.Id);
            DbContext.Entry(temp).CurrentValues.SetValues(article);
            DbContext.SaveChanges();
        }
        public void DeleteArticle(int id)
        {
            DbContext.Articles.Remove(GetArticle(id));
            DbContext.SaveChanges();
        }

        public void AddArticle(Article article)
        {
            DbContext.Articles.Add(article);
            DbContext.SaveChanges();
        }
    }
}