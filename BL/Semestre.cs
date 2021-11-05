using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT [IdSemestre],[Nombre] FROM [Semestre]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.Connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            result.Objects = new List<object>();

                            while (reader.Read())
                            {
                                ML.Semestre semestre = new ML.Semestre();
                                semestre.IdSemestre = reader.GetByte(0);
                                semestre.Nombre = reader.GetString(1);
                                
                                result.Objects.Add(semestre);
                            }


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
    }
}
