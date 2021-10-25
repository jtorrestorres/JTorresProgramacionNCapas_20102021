using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    class VentaMateria
    {
        public int IdVentaMateria { get; set; }
        public ML.Venta Venta { get; set; }
        public ML.Usuario Usuario { get; set; }
    }
}
