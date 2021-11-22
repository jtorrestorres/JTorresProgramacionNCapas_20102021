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
            materia.Errores = new List<object>();
            if (Session["RutaExcel"]!=null)
            {
                materia.Correct = true;
            }
            return View(materia);
        }

        [HttpPost]
        public ActionResult CargaMasiva(ML.ErrorExcel errorItem)
        {
            if (Session["RutaExcel"] != null) //Que ya tiene la ruta del archivo
            {
                string direccionExcel = (string)Session["RutaExcel"];
                string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"].ToString();
                string ConnectionString = CadenaConexion + direccionExcel;


                ML.Result resultDataTable = BL.Materia.ConvertToDataTable(direccionExcel, ConnectionString);

                if (resultDataTable.Correct)
                {
                    string ErrorMessage = "";
                    DataTable tableEmpleado = (DataTable)resultDataTable.Object;//unboxing
                    foreach(DataRow row in tableEmpleado.Rows)
                    {
                        ML.Materia materia = new ML.Materia(); //Empleado
                        materia.Nombre = row[0].ToString();
                        materia.Costo = decimal.Parse(row[1].ToString());

                        ML.Result resultMateria = BL.Materia.Add(materia);
                        if (!resultMateria.Correct)
                        {
                            ErrorMessage += resultMateria.ErrorMessage;
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        ViewBag.Message = "Los empleados han sido cargados correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrió un error al insertar los empleados" + ErrorMessage;
                    }
                   
                }

                //Cargar el archivo
            }
            else
            {
                //Validar el archivo
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
                                Session["RutaExcel"] = direccionExcel;
                                string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"].ToString();
                                string ConnectionString = CadenaConexion + direccionExcel;

                                ML.Result resultDataTable = BL.Materia.ConvertToDataTable(direccionExcel, ConnectionString);

                                if (resultDataTable.Correct)
                                {
                                    DataTable tableEmpleado = (DataTable)resultDataTable.Object;//unboxing
                                    ML.Result resultValidarExcel = BL.Materia.ValidarExcel(tableEmpleado);
                                    if (!resultValidarExcel.Correct) //si hubo errores
                                    {
                                        ML.ErrorExcel error = new ML.ErrorExcel();
                                        error.Errores = resultValidarExcel.Objects;
                                        return View(error);
                                    }
                                    else
                                    {
                                        ViewBag.Message = "Todos los registros han sido validados correctamente, puede proceder a cargarlos";
                                    }
                                }


                            }
                            catch (Exception ex)
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
            }
            return PartialView("Modal");
        }
    }
}