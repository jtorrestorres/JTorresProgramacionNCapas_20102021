using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Venta
    {
        public void Add()
        {
            //Leer el Id de Usuario
            ML.Venta venta = new ML.Venta();
            venta.Usuario = new ML.Usuario();//instancia
            venta.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            //while



            //Venta.Add
        }
       
       
    }
}
