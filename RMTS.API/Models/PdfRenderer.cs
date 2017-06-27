using System;
using System.IO;
using System.Web;
using iTextSharp.text.pdf;
using RMTS.Backend.Models;

namespace RMTS.API.Models
{
	public static class PdfRenderer
	{
		public static string Source => HttpContext.Current.Server.MapPath("~/Assets/proposal-form.pdf");
		public static string Target => HttpContext.Current.Server.MapPath("~/Assets/filled-form.pdf");

		public static bool Generate(Prospect prospect, string target, string source)
		{
			try
			{
				var pdfReader = new PdfReader(Source);
				var pdfStamper = new PdfStamper(pdfReader, new FileStream(Target, FileMode.Create));
				var pdfFormFields = pdfStamper.AcroFields;

				pdfFormFields.SetField("firstname", prospect.FirstName);
				pdfFormFields.SetField("infix", prospect.Infix);
				pdfFormFields.SetField("lastname", prospect.Surname);
				pdfFormFields.SetField("privateAddress", prospect.Address.ToString());
				pdfFormFields.SetField("phoneNumber", prospect.PhoneNumber);
				pdfFormFields.SetField("emailAddress", prospect.EmailAddress);
				pdfFormFields.SetField("profession", prospect.Profession);
				pdfFormFields.SetField("applicatorMotivation", prospect.Description);
				pdfFormFields.SetField("gender", "Man");

				pdfStamper.FormFlattening = true;
				pdfStamper.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
				return false;
			}
		}
	}
}
