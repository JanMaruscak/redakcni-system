using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedakcniSystem.Data;

namespace RedakcniSystem.Controllers
{
    [ApiController]
    public class ArticleController : Controller
    {

        private ApplicationDbContext _dbContext;

        public ArticleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Najde článek v databázi podle Id článku
        /// </summary>
        /// <param name="id">Id článku</param>
        /// <returns>Detail článku</returns>
        [HttpGet("/api/v1/article/detail")]
        public IActionResult Article(int id)
        {
            return Json(_dbContext.Articles.Include(x =>x.Tags).FirstOrDefault(x=>x.Id==id));
        }

        /// <summary>
        /// Vrátí list všech článků (Id, Title)
        /// </summary>
        /// <returns>List článků (Id, Title)</returns>
        [HttpGet("/api/v1/articles")]
        public IActionResult Articles()
        {
            return Json(_dbContext.Articles.Include(x => x.Tags).Select(x => new
            {
                Id = x.Id,
                Title = x.Title
            }));
        }
    }
}
