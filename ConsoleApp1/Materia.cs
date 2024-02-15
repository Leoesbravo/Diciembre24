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
            //Propiedad de navegacion
            materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = int.Parse(Console.ReadLine());

            bool resultado = BL.Materia.AddEF(materia);
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
        public static void GetAll()
        {
           var resultado = BL.Materia.GetAllEF();
           if(resultado.Item1 == true)
            {
                foreach (ML.Materia materiaRegistro in resultado.Item3.Materias)
                {
                    Console.WriteLine("ID Materia: " + materiaRegistro.IdMateria);
                    Console.WriteLine("Nombre: " + materiaRegistro.Nombre);
                    Console.WriteLine("Creditos: " + materiaRegistro.Creditos);
                    Console.WriteLine("Semestre: " + materiaRegistro.Semestre.IdSemestre);
                    Console.WriteLine("-------------------------------------");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al consultar la información" + resultado.Item2);
                Console.ReadKey();
            }

          
        }
        //insertar la informacion
       

    }
}

//terminar los metodos de LINQ
//Agregar nueva tabla ROl
//actualizar modelo de EF
//Actualizar del codigo(ML,PLy BL)