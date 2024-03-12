using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public string Nombre { get; set; }
        public byte Creditos { get; set; } 
        public int IdMateria { get; set; }
        public int Cantidad { get; set; } = 1;
        public List<object> Materias { get; set; }
        public string Costo { get; set; }

        //Propiedad de navegación
        // Propiedad que permite hacer referencia a otra clase
        public ML.Semestre Semestre { get; set; }

    }
}
