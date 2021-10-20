﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        //}
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Materia]([Nombre],[Creditos],[Costo] )VALUES (@Nombre, @Creditos, @Costo)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;

                        collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[2].Value = materia.Costo;
                     
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
        public static void Update()
        {

        }
        public static void Delete()
        {

        }
        public static void GetAll()
        {

        }
    }
}