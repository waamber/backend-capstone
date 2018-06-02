using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/quotes")]
	public class QuoteController : ApiController
	{
		[Route(""), HttpGet]
		public HttpResponseMessage ListShows()
		{
			var repo = new QuoteRepo();
			var result = repo.GetQuotes();

			return Request.CreateListRecordResponse(result);
		}
	}
}