using ComicBookGallery.Data;
using ComicBookGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookGallery.Controllers
{
    public class ComicBooksController : Controller
    {
        private ComicBookRepository _comicBookRepository = null;

        public ComicBooksController()
        {
            _comicBookRepository = new ComicBookRepository();
        }
        public IActionResult Index()
        {
            var comicBooks = _comicBookRepository.GetComicBooks();
            return View(comicBooks);
        }
        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                Response.StatusCode = 404;
                // I would return an actual 404 view if I had one
                return null;
            }
            var comicBook = _comicBookRepository.GetComicBook((int)id);
            return View(comicBook);
        }
    }
}
