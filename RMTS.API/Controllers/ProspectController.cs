using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using RMTS.API.Models;
using RMTS.API.Security;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
	[BasicAuthentication]
	[RoutePrefix("Prospect")]
	public class ProspectController : BasicController<Prospect>
	{
		private static readonly IProspectService ProspectService = new ProspectService(new EfProspectRepository());
		public ProspectController() : base(ProspectService) { }

		[HttpPost]
		[Route("GenerateProposal")]
		public IHttpActionResult GenerateProposal(Prospect data)
		{
			if (data == null) return BadRequest("Ongeldig xml bestand");

			var result = new HttpResponseMessage();

			if (PdfRenderer.Generate(data, PdfRenderer.Target, PdfRenderer.Source))
			{
				result.StatusCode = HttpStatusCode.OK;

				var stream = new FileStream(PdfRenderer.Target, FileMode.Open);

				result.Content = new StreamContent(stream);
				result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
				result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
				result.Content.Headers.ContentLength = stream.Length;
			}
			else
			{
				result.StatusCode = HttpStatusCode.BadRequest;
			}

			return ResponseMessage(result);
		}
	}
}
