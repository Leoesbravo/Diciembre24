using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        //recuperar la cadena de conexion
        public static string GetConnectionString()
        {
            //buscar la cadena en el archivo de configuracion de mi proyecto (App.config)
            return ConfigurationManager.ConnectionStrings["LEscogidoProgramacionNCapas"].ConnectionString;
        }
    }
}
