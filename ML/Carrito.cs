using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Carrito//Asignacion
    {
        public List<object> Materias { get; set; }
        public decimal CostoTotal { get; set; }
        public int TotalProductos { get; set; }
    }
    //public class Asignacion
    //{
    //    public ML.Paquete Paquete { get; set; }
    //    public ML.repartidor repartidor { get; set; }
    //    public List<object> Asignaciones { get; set; }
    //    public int TotalPaquetes { get; set; }
    //}
}
