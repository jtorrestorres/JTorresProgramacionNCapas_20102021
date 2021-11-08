using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            ML.Materia materia = new ML.Materia();
            materia.Materias = result.Objects;

            return View(materia);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }



        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            ML.Result resultSemestre = BL.Semestre.GetAll();
            materia.Semestre = new ML.Semestre();
            materia.Semestre.Semestres = resultSemestre.Objects;

         


            if (IdMateria == null) //Add
            { 
                
                return View(materia);
            }
            else //Update
            {
                ML.Result result = new ML.Result();
                result = BL.Materia.GetById(IdMateria.Value);
                if (result.Correct)
                {
                    materia = ((ML.Materia)result.Object);
                    return View(materia);
                }
                else
                {

                }
            }
            return View();
        }


        //[HttpGet]
        //public ActionResult Modal()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                materia.Imagen = ConvertToBytes(file);
            }

            if (materia.IdMateria == 0)
            {
                result = BL.Materia.Add(materia);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "La materia se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "La materia no se ha registrado correctamente " + result.ErrorMessage;
                }

            }
            else
            {
                result = BL.Materia.Update(materia);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "La materia se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "La materia no se ha actualizado correctamente " + result.ErrorMessage;
                }


            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                ViewBag.Mensaje = "La materia se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "La materia no se ha eliminado correctamente " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}