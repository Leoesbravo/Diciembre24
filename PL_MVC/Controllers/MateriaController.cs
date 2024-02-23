using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        //Action Methods -metodos dentro de un controlador
        public ActionResult GetAll()
        {
            var result  =  BL.Materia.GetAllEF();
            if (result.Item1 == true)
            {
                ML.Materia materia = result.Item3;
                return View(materia);
            }
            else
            {
                ML.Materia materia = new ML.Materia();
                return View(materia);
            }
            
        }
        public ActionResult Form(int? idMateria)
        {
            if (idMateria != null)
            {
                //GetById
                var result = BL.Materia.GetById(idMateria.Value);

                return View(result.Item3);
            }
            else
            {
                //add
                return View();
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if(materia.IdMateria != 0)
            {
                //UPDATE
                var update = BL.Materia.Update(materia);
            } else
            {
                //ADD
                var resultado = BL.Materia.AddEF(materia);

            }

            return View();
        }

    }
}