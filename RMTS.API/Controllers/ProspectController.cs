using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Xml.XPath;
using iTextSharp.text.pdf;
using RMTS.API.Models;
using RMTS.API.Security;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service;
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

		    string source = HttpContext.Current.Server.MapPath("~/Assets/proposal-form.pdf");
		    string target = HttpContext.Current.Server.MapPath("~/Assets/filled-form.pdf");

			var pdfReader = new PdfReader(source);
			var pdfStamper = new PdfStamper(pdfReader, new FileStream(target, FileMode.Create));
		    var pdfFormFields = pdfStamper.AcroFields;

		    pdfFormFields.SetField("firstname", data.FirstName);
		    pdfFormFields.SetField("infix", data.Infix);
		    pdfFormFields.SetField("lastname", data.Surname);
			pdfFormFields.SetField("privateAddress", data.Address.ToString());
		    pdfFormFields.SetField("phoneNumber", data.PhoneNumber);
		    pdfFormFields.SetField("emailAddress", data.EmailAddress);
		    pdfFormFields.SetField("profession", data.Profession);
		    pdfFormFields.SetField("applicatorMotivation", data.Description);
			pdfFormFields.SetField("gender", "Man");

			pdfStamper.FormFlattening = true;
			pdfStamper.Close();
			
			var result = new HttpResponseMessage(HttpStatusCode.OK);
			var stream = new FileStream(target, FileMode.Open);
			result.Content = new StreamContent(stream);
		    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
		    {
			    FileName = "test.pdf"
		    };
		    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
		    result.Content.Headers.ContentLength = stream.Length;
		    return ResponseMessage(result);
	    }
    }
}
