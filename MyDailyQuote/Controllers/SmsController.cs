using Hangfire;
using MyDailyQuote.Models;
using MyDailyQuote.Services;
using System.Web.Http;


namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/sms")]
	public class SmsController : ApiController
	{
		[Route(""), HttpPost]
		public void SendScheduledQuote(User user)
		{
			var repo = new RandomQuote();

			RecurringJob.AddOrUpdate("SendDailyText", () => repo.SendOutDailyQuote(user), "*/5 * * * *");
		}
	}
}