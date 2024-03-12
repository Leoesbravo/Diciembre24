using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaAsignacionController : Controller
    {
        public ActionResult Carrito()
        {
            if(Session["CarritoAsignacion"] == null)
            {             
                return View(new ML.Carrito());
            }
            else
            {
               ML.Carrito carrito = (ML.Carrito)Session["CarritoAsignacion"];
               return View(carrito);
            }
           
        }
        public ActionResult AddToSession(int idpaquete )
        {
            bool existe = false;
            if (Session["CarritoAsignacion"] == null)
            {
                ML.Carrito carrito = new ML.Carrito();
                carrito.Materias = new List<object>();

               
                var result = BL.Materia.GetById(idpaquete);
                carrito.Materias.Add(result.Item3);

                Session["CarritoAsignacion"] = carrito;
            }
            else
            {
                var carrito = (ML.Carrito)Session["CarritoAsignacion"];
                var result = BL.Materia.GetById(idpaquete);
                foreach (ML.Materia materia in carrito.Materias)
                {
                    if(idpaquete == materia.IdMateria)
                    {
                        materia.Cantidad += 1;
                        existe = true;
                        break;
                    }
                    else
                    {
                        //bandera 
                   
                    }
                 
                }
                if (existe == false)
                {
                    carrito.Materias.Add(result.Item3);
                }
                Session["CarritoAsignacion"] = carrito;
                //cuando ya hay productos           

            }
            return RedirectToAction("GetAll", "Materia");
        }
    }
}