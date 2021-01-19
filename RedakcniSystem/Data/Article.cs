using System;
using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string ShortText { get; set; }
        public string Tags { get; set; }

        public Article()
        {
            
        }
        public Article(string title)
        {
            Title = title;
        }
    }
}