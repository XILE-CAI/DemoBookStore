using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;
using DemoBookStore.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IPublisherService _publisherService;
        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IPublisherService publisherService)
        {
            this._bookService = bookService;
            this._authorService = authorService;
            this._genreService = genreService;
            this._publisherService = publisherService;
        }

        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString() }).ToList();
            model.GenreList = _genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() ,Selected=a.Id==model.AuthorId}).ToList();
            model.PublisherList = _publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString(),Selected= p.Id==model.PublisherId}).ToList();
            model.GenreList = _genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() ,Selected=g.Id==model.GenreId}).ToList();
            //not valid

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _bookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added successfully";
                return RedirectToAction(nameof(Add));
            }

            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var model = _bookService.FindById(id);
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id ==model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString(), Selected = p.Id ==model.PublisherId }).ToList();
            model.GenreList = _genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString(), Selected = g.Id ==model.GenreId }).ToList();
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString(), Selected = p.Id == model.PublisherId }).ToList();
            model.GenreList = _genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString(), Selected = g.Id == model.GenreId }).ToList();
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _bookService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated successfully";
                return RedirectToAction("GetAll");
            }

            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            bool result = _bookService.Delete(id);
            return RedirectToAction("GetAll");
        }


        public IActionResult GetAll()
        {
            var data = _bookService.GetAll();
            return View(data);
        }
    }
}
