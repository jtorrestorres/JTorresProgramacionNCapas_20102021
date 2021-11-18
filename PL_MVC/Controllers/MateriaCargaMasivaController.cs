using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace PL_MVC.Controllers
{
    public class MateriaCargaMasivaController : Controller
    {
        // GET: MateriaCargaMasiva
        [HttpGet]
        public ActionResult CargaMasiva()
        {
            ML.Materia materia = new ML.Materia();
            return View(materia);
        }

        [HttpPost]
        public ActionResult CargaMasiva(ML.Materia materia)
        {
            HttpPostedFileBase file = Request.Files["ExcelMaterias"];

            if (file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName).ToLower();
                if (extension == ".xlsx")
                {
                    string direccionExcel = Server.MapPath("~/ExcelCargaMasivaMaterias/") + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                    if (!System.IO.File.Exists(direccionExcel))
                    {
                        file.SaveAs(direccionExcel);
                        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + direccionExcel + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        BL.Materia.ConvertXSLXtoDataTable(direccionExcel, connString);
                    }

                }
                else
                {
                    ViewBag.Message = "Seleccione un archivo con extensión .xlsx";
                }
            }
            else
            {
                ViewBag.Message = "Seleccione un archivo";
            }
            return View();
        }
    }
    }