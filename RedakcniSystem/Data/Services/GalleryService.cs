using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace RedakcniSystem.Data
{
    public class GalleryService
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext DbContext { get; set; }


        public GalleryService(IWebHostEnvironment environment, ApplicationDbContext dbContext)
        {
            _environment = environment;
            DbContext = dbContext;
            foreach (var album in GetAlbums())
            {
                if (!dbContext.Albums.Contains(album))
                {
                    dbContext.Albums.Add(album);
                }
            }
        }


        public List<GalleryModels.Album> GetAlbums()
        {
            List<GalleryModels.Album> albums = new List<GalleryModels.Album>();

            DirectoryInfo info = new DirectoryInfo(_environment.ContentRootPath + "/wwwroot/Gallery/");

            foreach (var dir in info.GetDirectories())
            {
                albums.Add(new GalleryModels.Album()
                {
                    Name = dir.Name,
                    ImageUrl = $"/Gallery/{dir.Name}/{dir.GetFiles().FirstOrDefault()?.Name}",
                });
            }


            return albums;
        }
        
        public List<GalleryModels.Photo> GetPhotos(string name)
        {
            List<GalleryModels.Photo> photos = new List<GalleryModels.Photo>();

            DirectoryInfo info = new DirectoryInfo(_environment.ContentRootPath + "/wwwroot/Gallery/" + name);


            foreach(var file in info.GetFiles())
            {
                photos.Add(new GalleryModels.Photo()
                {
                    ImageUrl = $"/Gallery/{name}/{file.Name}",
                });
            }


            return photos;
        }


    }

}