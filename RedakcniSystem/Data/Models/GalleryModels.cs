using System.ComponentModel.DataAnnotations;

namespace RedakcniSystem.Data
{
    public class GalleryModels
    {
        public class Album
        {
            [Key]
            public string Name { get; set; }
            public string ImageUrl { get; set; }
        }

        public class Photo
        {
            [Key]
            public int Id { get; set; }
            public string ImageUrl { get; set; }
        }

    }
}