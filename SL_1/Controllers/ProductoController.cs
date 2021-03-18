using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace SL_1.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Producto/5
        [HttpGet]
        [Route("api/Producto/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
          
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

           // return "value";
        }
        
        // POST: api/Producto        
        [HttpPost]
        [Route("api/Producto/Add")]
        public IHttpActionResult Post([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT: api/Producto/5
        [HttpPut]
        [Route("api/Producto/Update")]
        public IHttpActionResult Put([FromBody]ML.Producto producto)
        {
            var result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Producto/5
        [HttpDelete]
        [Route("api/Producto/Delete/{IdProducto}")]
        public IHttpActionResult Delete(int IdProducto)
        {
            var result = BL.Producto.Delete(IdProducto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
      
    }
}
