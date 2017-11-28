using DatosPersonalesWS.Service;
using System;
using System.Web.Http;
namespace DatosPersonalesWS.Controllers
{
	[RoutePrefix("api/mailing")]
	public class MailingController : ApiController
	{
		private MailingService mailingService = new MailingService();
		[HttpGet, Route("EmailIsValid")]
		public bool EmailIsValid(string address)
		{
			return this.mailingService.EmailIsValid(address);
		}
		[HttpGet, Route("EmailIsValidRegEx")]
		public bool EmailIsValidRegEx(string address)
		{
			return this.mailingService.EmailIsValidRegEx(address);
		}
	}
}
