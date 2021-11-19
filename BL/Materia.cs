using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Objects;

namespace BL
{
    public class Materia
    {
        //public static void Add(ML.Materia materia)
        //{            
        //    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=JTorresProgramacionNCapas_20102021;Persist Security Info=True;User ID=sa;Password=pass@word1"))
        //    {
        //        SqlCommand cmd = new SqlCommand("INSERT INTO [Materia]([Nombre],[Creditos],[Costo]) VALUES (@Nombre,@Creditos,@Costo)", conn);
        //        cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
        //        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
        //        cmd.Parameters.AddWithValue("@Costo", materia.Costo);
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}//
        public static ML.Result GetAll(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdSemestre", SqlDbType.Int);
                        collection[0].Value = materia.Semestre.IdSemestre;
                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            result.Objects = new List<object>();

                            while (reader.Read())
                            {
                                materia = new ML.Materia();
                                materia.IdMateria = reader.GetInt32(0);
                                materia.Nombre = reader.GetString(1);
                                materia.Creditos = reader.GetByte(2);
                                materia.Costo = reader.GetDecimal(3);

                                // var x = reader.GetByte(4);
                                var y = reader.GetSqlValue(4);
                                var z = reader.GetValue(4);
                                var a = reader.GetStream(4);
                                //var b = (byte[])reader["Imagen"];

                                //if (b.Length ==0)
                                //{
                                //    materia.Imagen = null;
                                //}
                                //else
                                //{
                                //    materia.Imagen = (byte[])reader["Imagen"];
                                //}
                                // materia.Imagen = reader.GetValue(4) != "" ? (byte[])reader.GetValue(4) : null;

                                result.Objects.Add(materia);
                            }
                            //S

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Materia";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar);
                        collection[0].Value = IdMateria;
                        cmd.Parameters.AddRange(collection);
                        DataTable tableMateria = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableMateria);

                        if (tableMateria.Rows.Count > 0)
                        {
                            DataRow row = tableMateria.Rows[0];

                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = int.Parse(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Creditos = byte.Parse(row[2].ToString());
                            materia.Costo = decimal.Parse(row[3].ToString());
                            result.Object = materia; //boxing

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Materia";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Materia]([Nombre],[Creditos],[Costo], [Imagen] )VALUES (@Nombre, @Creditos, @Costo, @Imagen)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;

                        collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[2].Value = materia.Costo;

                        collection[3] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                        collection[3].Value = materia.Imagen;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La materia no se pudo insertar correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //public static ML.Result AddEF(ML.Materia materia)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.JTorresProgramacionNCapas_20102021Entities context = new DL_EF.JTorresProgramacionNCapas_20102021Entities())
        //        {
        //            //identity
        //            ObjectParameter IdMateria = new ObjectParameter("myOutputParamBool", typeof(bool));
        //            var query = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Costo, IdMateria);


        //            if (query >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se insertó el registro";
        //            }

        //            result.Correct = true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}


        public static ML.Result Update(ML.Materia materia)
        {
            return new ML.Result();
        }
        public static ML.Result Delete(int IdMateria)
        {
            return new ML.Result();
        }

        public static ML.Result ConvertToDataTable(string strFilePath, string connString)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (OleDbConnection context = new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;


                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tableEmpleado = new DataTable();

                        da.Fill(tableEmpleado);

                        result.Object = tableEmpleado;

                        if (tableEmpleado.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                
            }
           
            return result;

        }


        public static ML.Result ValidarExcel(DataTable tableEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //DataTable  //Rows //Columns
                foreach(DataRow row in tableEmpleado.Rows)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();

                    if (row[0].ToString() == "")
                    {
                        error.Message += "Por favor ingresar el número de empleado";
                    }
                    if (row[1].ToString() == "")
                    {
                        error.Message += "Por favor ingresar el nombre del empleado";
                    }
                    if (row[2].ToString() == "")
                    {
                        error.Message += "Por favor ingresar el Apellido Paterno del empleado";
                    }
                    if (row[3].ToString() == "")
                    {
                        error.Message += "Por favor ingresar el Apellido Materno del empleado";
                    }
                    if (row[4].ToString() == "")
                    {
                        error.Message += "Por favor ingresar el Email del empleado";
                    }

                    //error.Message += (row[4].ToString() == "") ? "Por favor ingresar el Email del empleado" : "";

                    if (error.Message!=null)
                    {
                        result.Objects.Add(error);
                    }
                    

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;

        }
        //result.Objects = new List<object>();

        //foreach(DataRow row in dt.Rows)
        //{
        //    ML.ErrorExcel error = new ML.ErrorExcel();

        //    if (row[0] != "")
        //    {
        //        error.Message = "Por favor ingresar el nombre";
        //    }
        //    if (row[1] != "")
        //    {
        //        error.Message = "Por favor ingresar el apellido paterno";
        //    }
        //    result.Objects.Add(error);
        //}

    }
}
