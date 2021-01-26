using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        public string Html { get; set; }
        public string Link { get; set; }
    }
}