using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.WEB.BUSSINESS;
using NS.WEB.DATABASE.Entities;
using NS.WEB.MODEL;
using System;
using System.IO;

namespace NS.WEB.FOODORD.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBussiness _IBussiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IBussiness IBussiness, IWebHostEnvironment webHostEnvironment)
        {
            _IBussiness = IBussiness;       
            _webHostEnvironment = webHostEnvironment;
        }

        //Will Show all the Dishes
        public ActionResult ShowDish()
        {
            return View(_IBussiness.ShowDish());
        }

        //Detail of specific Dish
        public ActionResult Details(int id)
        {
            return View(_IBussiness.GetDishById(id));
        }

        //Admin will add the dishes
        
        public ActionResult AddDish()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDish(DishModel dishModel)
        {
            if (ModelState.IsValid)
            {
                if (dishModel.DishPhoto != null)
                {
                    string folder = "dish/dishpicture";
                    folder += Guid.NewGuid().ToString() + "-" + dishModel.DishPhoto.FileName;       //for uplodaing multiple images

                    dishModel.ImgUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);    // used to recognise path during deployment 

                    dishModel.DishPhoto.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }
                _IBussiness.AddDish(dishModel);

                return RedirectToAction("Index","Home");

            }

            return View();
        }

        //Admin will update the dishes
        public ActionResult UpdateDish(int id)
        {
            return View(_IBussiness.GetDishById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDish(DishTable dishTable,int Id)
        {
            var wwwrootpath = _webHostEnvironment.WebRootPath;
            _IBussiness.UpdateDish(dishTable, Id, wwwrootpath);
            return RedirectToAction("ShowDish");

        }

        //Admin will delete the dishes
        public ActionResult DeleteDish(int id)
        {
            return View(_IBussiness.GetDishById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDish(DishTable dishTable , int Id)
        {
            _IBussiness.DeleteDish(dishTable, Id);
            return RedirectToAction("ShowDish");
        }
    }
}
