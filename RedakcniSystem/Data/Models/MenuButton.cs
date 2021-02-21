using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class MenuButton
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }

        public MenuButton()
        {
            
        }
    }
}