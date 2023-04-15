using DemoBookStore.Models.Domain;
using DemoBookStore.Repositories.Abstract;
using DemoBookStore.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace DemoBookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            this._publisherService = publisherService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _publisherService.Add(model);
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
            var record = _publisherService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            //not valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _publisherService.Update(model);
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
            bool result = _publisherService.Delete(id);
            return RedirectToAction("GetAll");
        }


        public IActionResult GetAll()
        {
            var data = _publisherService.GetAll();
            return View(data);
        }
    }
}
