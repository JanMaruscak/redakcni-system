using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        public Tag()
        {
            
        }

        public Tag(string content)
        {
            Content = content;
        }
    }
}