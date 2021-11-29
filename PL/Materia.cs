using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();

            //Nombre
            Console.WriteLine("Ingresa el nombre de la materia");
            materia.Nombre = Console.ReadLine();
            //Creditos
            Console.WriteLine("Ingresa los créditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());
            //Costo
            Console.WriteLine("Ingresa el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            ServiceMateria.MateriaClient objServicioMateria = new ServiceMateria.MateriaClient();
            //TimeOut  -WebConfig -9 seg -> 18 seg
            //
            ServiceMateria.Result result = objServicioMateria.Add(materia);  // Consumo de servicio WCF
            //ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                Console.WriteLine("La materia fue insertada correctamente");
            }
            else
            {
                Console.WriteLine("La materia no fue insertada correctamente. Error: " + result.ErrorMessage);
            }

        }
        public static void Update()
        {

        }
        public static void Delete()
        {

        }
        public static void GetAll()
        {
            ML.Result result = BL.Materia.GetAll(new ML.Materia());

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + materia.IdMateria);
                    Console.WriteLine("Nombre: " + materia.Nombre);
                    Console.WriteLine("Creditos: " + materia.Creditos);
                    Console.WriteLine("Costo: " + materia.Costo);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }


        public static void GetById()
        {
            ML.Result result = BL.Materia.GetById(2);

            if (result.Correct)
            {

                //unboxing 
                ML.Materia materia = ((ML.Materia)result.Object);

                Console.WriteLine("IdMateria: " + materia.IdMateria);
                Console.WriteLine("Nombre: " + materia.Nombre);
                Console.WriteLine("Creditos: " + materia.Creditos);
                Console.WriteLine("Costo: " + materia.Costo);
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
    }
}
