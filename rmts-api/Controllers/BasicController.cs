using System;
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
            if (id == null) return BadRequest("Geen geldig item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

            return Ok(service.Find(id.Value));
        }

        [HttpPost]
        public IHttpActionResult Create(T item)
        {
            if (item == null) return BadRequest("Geen geldig item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

	        try
	        {
		        if (service.Create(item))
			        return Ok("Item succesvol toegevoegd.");
		        else
					return BadRequest("Item is niet toegevoegd.");
			}
	        catch (Exception e)
	        {
		        return InternalServerError(e);
	        }
        }

        [HttpPut]
        public IHttpActionResult Update(T item)
        {
            if (item == null) return BadRequest("Geen geldig item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

	        try
	        {
		        if (service.Update(item))
			        return Ok("Item succesvol geupdatet.");
		        else
			        return BadRequest("Item niet geupdatet.");
	        }
	        catch (Exception e)
	        {
		        return InternalServerError(e);
	        }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null) return BadRequest("Geen geldig item meegegeven");
            if (service == null) return BadRequest("Service is not defined.");

	        try
	        {
		        if (service.Delete(id))
			        return Ok("Item succesvol verwijderd.");
		        return BadRequest("Item niet verwijderd.");
	        }
	        catch (Exception e)
	        {
		        return InternalServerError(e);
	        }
        }
    }
}
