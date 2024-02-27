using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static (bool, string, ML.Usuario, Exception) GetbyEmail(string email)
        {
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasFebreroEntities context = new DL_EF.LEscogidoProgramacionNCapasFebreroEntities())
                {
                    var registros = context.UsuarioGetByEmail(email).SingleOrDefault();

                    if (registros != null)
                    {
                        ML.Usuario usuarioObj = new ML.Usuario();
                        usuarioObj.IdUsuario = registros.IdUsuario;
                        usuarioObj.Email = registros.UserName;
                        usuarioObj.Password = registros.Password;



                        //return (true, null, materia, null);
                        return (true, null, usuarioObj, null);
                    }
                    else
                    {
                        return (false, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }
        }
    }
}
