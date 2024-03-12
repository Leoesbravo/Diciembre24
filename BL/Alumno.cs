using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class Alumno
    {
        public static (bool, string, ML.Alumno, Exception) GetAllEF()
        {
            ML.Alumno alumno = new ML.Alumno ();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasFebreroEntities context = new DL_EF.LEscogidoProgramacionNCapasFebreroEntities())
                {
                    var registros = context.AlumnoGetAll().ToList();

                    if (registros.Count > 0)
                    {
                        alumno.Alumnos = new List<object>();
                        foreach (var registro in registros)
                        {
                            ML.Alumno alumnoobj = new ML.Alumno();
                            alumnoobj.IdAlumno = registro.AlumnoId;
                            alumnoobj.Nombre = registro.Nombre;
                            alumnoobj.ApellidoMaterno = registro.ApellidoMaterno;
                            alumnoobj.FechaNacimiento = registro.FechaNacimiento.Value.ToString("dd-mm-yyyy");
                            alumnoobj.ApellidoPaterno = registro.ApellidoPaterno;

                            alumno.Alumnos.Add(alumnoobj);
                        }
                        return (true, null, alumno, null);
                    }
                    else
                    {
                        return (false, null, alumno, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, alumno, ex);
            }
        }
        public static (bool,string, Exception) Add(ML.Alumno alumno)
        {
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasFebreroEntities context = new DL_EF.LEscogidoProgramacionNCapasFebreroEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoMaterno, alumno.ApellidoPaterno, alumno.FechaNacimiento, alumno.Horario.Turno, alumno.Horario.CicloEscolar, alumno.Horario.Grupo.IdGrupo);

                    if (query > 1)
                    {
                        return (true,null,null);
                    }
                    else
                    {
                        return (false, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }
    }
}
