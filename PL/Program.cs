using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        
        public static bool SimbolosSimples(string cadena)
        {
            bool result = true;

            for(int i=1; i<cadena.Length-1; i++)
            {
                char c = cadena[i];
                int valorCaracter = (int)c;                
                if ( (valorCaracter >=65 && valorCaracter <= 90) || (valorCaracter >= 97 && valorCaracter <= 122))
                {
                    //verifica a los costados
                    if (cadena[i-1]!='+' || cadena[i+1]!='+')
                    {
                        return false;
                    }
                }              
            }
            return result;
        }


        public static string cambioLetras(string cadena) // hola ipmb
        {
            string nuevaCadena="";
            for (int i = 0; i < cadena.Length ; i++)
            {
                char c = cadena[i];
                int nuevaValor = (int)c+1;
                char nuevaLetra= (char)nuevaValor;

                nuevaCadena =  nuevaCadena+ nuevaLetra.ToString();
            }
            return nuevaCadena;
        }

        public static void Suma(ML.Materia materia)
        {

        }
        static void Main(string[] args)
        {
            ML.Materia materia = new ML.Materia();
            Suma(materia);



            cambioLetras("hola");
            Console.WriteLine(SimbolosSimples("+a-+==+c+=a+")); 
            string c = "";
            string Cadena= "Hola";
          //  Ordenar(Cadena.ToCharArray());

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

    //public static void Ordenar(char[] cadena)
    //{
    //    for (int i = 0; i < cadena.Length; i++)
    //    {
    //        for (int j = 1; j < cadena.Length - 1; j++)
    //        {
    //            if (cadena[i] > cadena[j])  //0 b 1 a
    //            {
    //                char aux = cadena[i];
    //                cadena[i] = cadena[j];

    //            }
    //        }
    //    }
    //}
}
