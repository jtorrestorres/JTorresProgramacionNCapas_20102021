using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace PL_MVC.Controllers
{
    public class MateriaCargaMasivaController : Controller
    {
        // GET: MateriaCargaMasiva
        [HttpGet]
        public ActionResult CargaMasiva()
        {
            ML.ErrorExcel materia = new ML.ErrorExcel();
            return View(materia);
        }

        [HttpPost]
        public ActionResult CargaMasiva(ML.Materia materia)
        {
            HttpPostedFileBase file = Request.Files["ExcelMaterias"];

            if (file.ContentLength > 0)//Si el usuario seleccionó un excel
            {
                string extension = Path.GetExtension(file.FileName).ToLower();
                if (extension == ".xlsx")
                {
                    string direccionExcel = Server.MapPath("~/ExcelCargaMasivaMaterias/") + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                    if (!System.IO.File.Exists(direccionExcel))
                    {
                        //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + direccionExcel + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                        try
                        {
                            file.SaveAs(direccionExcel);
                            string CadenaConexion= System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"].ToString();
                            string ConnectionString = CadenaConexion + direccionExcel;

                            ML.Result resultDataTable= BL.Materia.ConvertToDataTable(direccionExcel, ConnectionString);
                            
                            if (resultDataTable.Correct)
                            {
                                DataTable tableEmpleado = (DataTable)resultDataTable.Object;//unboxing
                                ML.Result resultValidarExcel = BL.Materia.ValidarExcel(tableEmpleado);
                                if (resultValidarExcel.Correct)
                                {
                                    //foreach insertar
                                }
                                else
                                {
                                    ML.ErrorExcel error = new ML.ErrorExcel();
                                    error.Errores = resultValidarExcel.Objects;
                                    return View(error);
                                }
                            }


                        }
                        catch(Exception ex)
                        {
                            ViewBag.Message = ex.Message;
                        }
                        
                    }
                    else
                    {
                        ViewBag.Message = "Ya existe el nombre del archivo, por favor renombrarlo";
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