using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    [ServiceContract]
    public interface IMateria
    {
        [OperationContract]
        SL.Result Add(ML.Materia materia);
        SL.Result Update(ML.Materia materia);
        SL.Result Delete(int IdMateria);
    }
}
