using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class ArticleId
    {
        [Key]
        public int Id { get; set; }
        public int Article { get; set; }
    }
}