using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //Add
        //Delete
        //Update
        //GetAll
        //GetById
        public static bool Add(ML.Materia materia)
        {
            bool resultado = false;
            try
            {
                //SqlConnection- hacer la conexion a la BD
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                   // string query = "INSERT INTO Materia (Nombre, Creditos, Semestre) VALUES (@Nombre,@Creditos,@Semestre)";
                    string query = "MateriaAdd";

                    //SqlCommand- ejecutar sentencias de SQL
                    SqlCommand commnad = new SqlCommand();
                    commnad.Connection = context;
                    commnad.CommandText = query;
                    commnad.CommandType = CommandType.StoredProcedure;

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
        public static bool AddEF(ML.Materia materia)
        {
            bool resultado = false;
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasFebreroEntities context = new DL_EF.LEscogidoProgramacionNCapasFebreroEntities())
                {
                    int rowsAffected = context.MateriaAdd(materia.Nombre,materia.Creditos, materia.Semestre);
                    if(rowsAffected >0)
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

            }
            return resultado;
        }

        public static bool Delete(int idMateria)
        {
            bool resultado = false;
            try
            {
                //SqlConnection- hacer la conexion a la BD
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DELETE FROM Materia WHERE IdMateria = @IdMateria";

                    //SqlCommand- ejecutar sentencias de SQL
                    SqlCommand commnad = new SqlCommand();
                    commnad.Connection = context;
                    commnad.CommandText = query;

                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = new SqlParameter("@IdMateria", System.Data.SqlDbType.Int);
                    parameters[0].Value = idMateria;


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
        public static bool Update(ML.Materia materia)
        {
            bool resultado = false;
            try
            {
                //SqlConnection- hacer la conexion a la BD
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UPDATE Materia SET Nombre = @Nombre, Creditos = @Creditos, Semestre = @Semestre WHERE IdMateria = @IdMateria";

                    //SqlCommand- ejecutar sentencias de SQL
                    SqlCommand commnad = new SqlCommand();
                    commnad.Connection = context;
                    commnad.CommandText = query;

                    SqlParameter[] parameters = new SqlParameter[4];

                    parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                    parameters[0].Value = materia.Nombre;
                    parameters[1] = new SqlParameter("@Creditos", System.Data.SqlDbType.TinyInt);
                    parameters[1].Value = materia.Creditos;
                    parameters[2] = new SqlParameter("@Semestre", System.Data.SqlDbType.VarChar);
                    parameters[2].Value = materia.Semestre;
                    parameters[3] = new SqlParameter("@Materia", System.Data.SqlDbType.Int);
                    parameters[3].Value = materia.IdMateria;

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
        public static ML.Materia GetAllEF()
        {
            ML.Materia materia = new ML.Materia();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasFebreroEntities context = new DL_EF.LEscogidoProgramacionNCapasFebreroEntities())
                {
                    var registros = context.MateriaGetAll().ToList();

                    if(registros.Count > 0)
                    {
                        materia.Materias = new List<object>();
                        foreach( var registro in registros)
                        {
                            ML.Materia materiaObj = new ML.Materia();
                            materiaObj.IdMateria = registro.IdMateria;
                            materiaObj.IdMateria = registro.IdMateria;
                            materiaObj.IdMateria = registro.IdMateria;
                            materiaObj.IdMateria = registro.IdMateria;

                            materia.Materias.Add(materiaObj);
                        }
                    }
                    else
                    {
                        //manejo de exepcion
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return materia;
        }
        public static ML.Materia GetAll()
        {
        
            ML.Materia materia = new ML.Materia();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetAll";

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable tableMateria = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(tableMateria);

                    if (tableMateria.Rows.Count > 0)
                    {
                        materia.Materias = new List<object>(); //iniciar mi lista
                        foreach (DataRow fila in tableMateria.Rows)
                        {
                            ML.Materia materiaobj = new ML.Materia();
                            materiaobj.IdMateria = int.Parse(fila[0].ToString());
                            materiaobj.Nombre = fila[1].ToString();
                            materiaobj.Creditos = byte.Parse(fila[2].ToString());
                            materiaobj.Semestre = fila[3].ToString();

                            materia.Materias.Add(materiaobj);
                        }

                    }
                    else
                    {
                        //pendiente
                        //no srivio
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return materia;
        }
        //public static ML.Materia GetById(ML.Materia materia)
        //{

        //}

        //Stored procedure -SQL

    }
}
