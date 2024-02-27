using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            var result = BL.Alumno.GetAllEF();
            if (result.Item1 == true)
            {
                ML.Alumno alumno = result.Item3;
                return View(alumno);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Form(int? idAlumno)
        {
            if (idAlumno != null)
            {
                //GetById Alumno            
                return View();
            }
            else
            {
                //add
                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if (alumno.IdAlumno != 0)
            {
                //GetById Alumno            
                return View();
            }
            else
            {
                var result = BL.Alumno.Add(alumno);
                if (result.Item1)
                {
                    ViewBag.Mensaje = "Funciono";
                }
                return PartialView("Modal");
            }
        }
    }
}