using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Materia
    {
        //pedir la informacion
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();
            Console.WriteLine("Ingresa el nombre del nuevo Materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa los creditos de la nueva materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el semestre al que pertenece la materia");
            materia.Semestre = Console.ReadLine();

            bool resultado = BL.Materia.Add(materia);
            if (resultado == true)
            {
                Console.WriteLine("Se ha insertado el registro");
            }
            else
            {
                Console.WriteLine("No se ha insertado el registro");
            }
            Console.ReadKey();
        }
        //insertar la informacion
       

    }
}

//Insertar -Add
//actualizar -Update
//Eliminar -Delete
//Consultar toda la informacion con SQL Client -GetAll
//Consultar filtrado por id con SQL Client - GetById

//Update 
//Delete