using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class FavoriteArticles
    {
        [Key]
        public int Id { get; set; }
        public List<ArticleId> LikedArticles { get; set; }
        public string UserId { get; set; }
    }
}