using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RedakcniSystem.Data
{
    public class ArticleService
    {
        private ApplicationDbContext DbContext { get; set; }
        public ArticleService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Article> GetArticles()
        {
            var articles = DbContext.Articles.Include(a => a.Tags).ToList();
            return articles;
        }
        public Article GetArticle(int id)
        {
            return DbContext.Articles.Include(a => a.Tags).FirstOrDefault((a) => a.Id == id);
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

        public List<Article> Search(Search Search)
        {
            Search.Content = Search.Content.ToLower();
            var articles = GetArticles();
            var result = articles.Where(t => t.Title.ToLower().Contains(Search.Content) || t.ShortText.ToLower().Contains(Search.Content));
            return result.ToList();
        }
    }
}