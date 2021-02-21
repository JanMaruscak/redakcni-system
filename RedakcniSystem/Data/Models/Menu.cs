using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }

        public List<MenuButton> Buttons { get; set; }

        public Menu()
        {
            
        }
    }
}