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
        

        public void LikeArticle(int articleId, string userId)
        {
            if(!DbContext.FavoriteArticles.Local.Any(x => x.UserId == userId))
            {
                DbContext.FavoriteArticles.Add(new FavoriteArticles() {LikedArticles = new List<ArticleId>(),UserId = userId});
            }
            DbContext.FavoriteArticles.Include(a => a.LikedArticles).First(x => x.UserId == userId)?.LikedArticles.Add(new ArticleId(){Article = articleId});
            DbContext.SaveChanges();
        }

        public List<ArticleId> GetLiked(string userId)
        {
            if(!DbContext.FavoriteArticles.Local.Any(x => x.UserId == userId))
            {
                DbContext.FavoriteArticles.Add(new FavoriteArticles() {LikedArticles = new List<ArticleId>(),UserId = userId});
            }
            DbContext.SaveChanges();
            return DbContext.FavoriteArticles.Include(a => a.LikedArticles).FirstOrDefault(x => x.UserId == userId)?.LikedArticles;
        }

        public void UnlikeArticle(int articleId, string userId)
        {
            if(!DbContext.FavoriteArticles.Local.Any(x => x.UserId == userId))
            {
                DbContext.FavoriteArticles.Add(new FavoriteArticles() {LikedArticles = new List<ArticleId>(),UserId = userId});
            }
            DbContext.FavoriteArticles.Include(a => a.LikedArticles).First(x => x.UserId == userId)?.LikedArticles.RemoveAll(x => x.Article == articleId);
            DbContext.SaveChanges();
        }
    }
}