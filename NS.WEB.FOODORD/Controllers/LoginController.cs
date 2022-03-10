using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.WEB.DATABASE.Entities;
using NS.WEB.LOGINBUSSINESS;
using NS.WEB.MODEL;
using System;
using System.Linq;
using System.IO;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace NS.WEB.FOODORD.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginBussiness _ILoginBussiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LoginController(ILoginBussiness ILoginBussiness, IWebHostEnvironment webHostEnvironment)
        {
            _ILoginBussiness = ILoginBussiness;
            _webHostEnvironment= webHostEnvironment;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
		{
            return View();
		}
        [HttpPost]
        public ActionResult Login(CustomerTable customerTable)
        {
            var result = _ILoginBussiness.Login(customerTable);
            
            
            if(result!=null)
			{
				var Claims = new[]
				{
                    new Claim(ClaimTypes.Name,result.CustomerName),
                    new Claim(ClaimTypes.Role , result.RoleType)
				};
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(Identity));
                TempData["UserName"] = result.CustomerName;
                return RedirectToAction("Secret");
			}
            return View("Registration");
        }

        public IActionResult LogOut()
		{
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
		}
        
        [Authorize(Roles="Admin")]
        public IActionResult Secret()
		{
            return View();
		}
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (userModel.UserPhoto != null)
                {
                    string folder = "user/userpicture";
                    folder += Guid.NewGuid().ToString() + "-" + userModel.UserPhoto.FileName;       //for uplodaing multiple images

                    userModel.ImgUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);    // used to recognise path during deployment 

                    userModel.UserPhoto.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }
                _ILoginBussiness.Registration(userModel);

                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
