using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string password, string email)
        {
            var result = BL.Usuario.GetbyEmail(email);
            if (result.Item1)
            {
                if(result.Item3.Password == password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Text = "Contraseña invalido";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Text = "Correo invalido" + result.Item2;
                return PartialView("Modal");
            }
        }
    }
}