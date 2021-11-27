using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: api/Materia //GETALL
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {

            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();
            materia.Nombre = "";
            ML.Result result= BL.Materia.GetAll(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
                
           
        }

        // GETById: api/Materia/5
        [HttpGet]
        [Route("api/Materia/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
         
            ML.Result result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        // POST: api/Materia
        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }
      

        // PUT: api/Materia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Materia/5
        public void Delete(int id)
        {
        }
    }
}
