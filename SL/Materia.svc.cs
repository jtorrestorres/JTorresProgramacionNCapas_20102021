using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Materia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Materia.svc or Materia.svc.cs at the Solution Explorer and start debugging.
    public class Materia : IMateria
    {
        //soap ui
        public SL.Result Add(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);

            //SL.Result resultServicio = new SL.Result();
            //resultServicio.Correct = result.Correct;
            //resultServicio.ErrorMessage = result.ErrorMessage;
            //resultServicio.Ex = result.Ex;
            //resultServicio.Object = result.Object;
            //resultServicio.Objects = result.Objects;

            //return resultServicio;

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL.Result Update(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL.Result Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
