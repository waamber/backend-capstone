using MyDailyQuote.Models;
using MyDailyQuote.Services;
using System.Net.Http;
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

		[Route("{userId}"), HttpGet]
		public HttpResponseMessage GetRandomQuote(int userId)
		{
			var repo = new QuoteRepo();
			var result = repo.GetRandomQuote(userId);

			return Request.CreateResponse(result);
		}

		[Route("add"),HttpPost]
		public HttpResponseMessage AddQuote(Quote quote)
		{
			var repo = new QuoteRepo();
			var result = repo.CreateQuote(quote);

			return Request.CreateAddRecordResponse(result);
		}
	}
}