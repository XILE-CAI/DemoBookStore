using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DemoBookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _authorService.Add(model);
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
            var record = _authorService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _authorService.Update(model);
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
            bool result = _authorService.Delete(id);
            return RedirectToAction("GetAll");
        }


        public IActionResult GetAll()
        {
            var data = _authorService.GetAll();
            return View(data);
        }
    }
}
