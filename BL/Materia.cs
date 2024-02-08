using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static bool Add(ML.Materia materia)
        {
            bool resultado = false;
            try
            {
                //SqlConnection- hacer la conexion a la BD
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO Materia (Nombre, Creditos, Semestre) VALUES (@Nombre,@Creditos,@Semestre)";

                    //SqlCommand- ejecutar sentencias de SQL
                    SqlCommand commnad = new SqlCommand();
                    commnad.Connection = context;
                    commnad.CommandText = query;

                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                    parameters[0].Value = materia.Nombre;
                    parameters[1] = new SqlParameter("@Creditos", System.Data.SqlDbType.TinyInt);
                    parameters[1].Value = materia.Creditos;
                    parameters[2] = new SqlParameter("@Semestre", System.Data.SqlDbType.VarChar);
                    parameters[2].Value = materia.Semestre;

                    commnad.Parameters.AddRange(parameters);

                    commnad.Connection.Open();
                    int rowsAffected = commnad.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }

            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }
    }
}
