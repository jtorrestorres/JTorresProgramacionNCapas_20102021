using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }

        [Required]
        public string Nombre { get; set; }


        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese los créditos")]
        public byte Creditos { get; set; }
        [Required(ErrorMessage ="Ingrese el costo")]
        [Range(1,30, ErrorMessage ="Debe ingresar un valor entre 1 y 30")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public decimal Costo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<object> Materias { get; set; }
        public ML.Semestre Semestre { get; set; }

        public byte[] Imagen { get; set; }

        public string Action { get; set; }

        [Required]//decoradores
        [Display(Name ="Fecha de registro")]
        public string FechaRegistro { get; set; }
        public bool Status { get; set; }  //drop down list
        public string Password { get; set; }
    }
}
