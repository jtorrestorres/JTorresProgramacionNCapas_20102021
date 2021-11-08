using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            PL.Materia.GetById();
            PL.Materia.Add();
            string mensage = "";
            if (5 > 6)
            {
                mensage = "El número es menor";                
            }
            else
            {
                mensage = "El número 6 es mayor";
            }

            mensage = 5 > 6 ? "El número 5 es menor" : "El número 6 es mayor";
        }
    }
}
