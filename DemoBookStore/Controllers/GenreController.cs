using DemoBookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using DemoBookStore.Models.Domain;

namespace DemoBookStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            this._genreService = genreService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _genreService.Add(model);
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
            var record = _genreService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _genreService.Update(model);
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
            bool result = _genreService.Delete(id);
            return RedirectToAction("GetAll");
        }


        public IActionResult GetAll()
        {
            var data = _genreService.GetAll();
            return View(data);
        }
    }
}
