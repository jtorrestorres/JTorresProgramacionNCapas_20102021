﻿using System;
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

            ML.Result result= BL.Materia.Add(materia);

            if(result.Correct)
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

        }
    }
}
