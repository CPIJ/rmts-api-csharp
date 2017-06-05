using System.Web.Http;
using RMTS.Backend.Data.Service;
using RMTS.Backend.Data.Service.Interface;

namespace RMTS.API.Controllers
{
    public abstract class BasicController<T> : ApiController
    {
        private readonly BasicService<T> service;

	    protected BasicController(BasicService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("All")]
        public IHttpActionResult GetAll()
        { 
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Find(int? id)
        {
            if (id == null) return BadRequest("Geen item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.Find(id.Value));
        }

        [HttpPost]
        public IHttpActionResult Create(T item)
        {
            if (item == null) return BadRequest("Geen item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.Create(item));
        }

        [HttpPut]
        public IHttpActionResult Update(T item)
        {
            if (item == null) return BadRequest("Geen item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.Update(item));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null) return BadRequest("Geen item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.Delete(id.Value));
        }
    }
}
