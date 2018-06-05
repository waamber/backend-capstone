using MyDailyQuote.Models;
using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/sms")]
	public class SmsController : ApiController
	{
		[Route(""), HttpPost]
		public void SendQuote(User user)
		{
			var accountSid = "ACb683348bef9a93aa101862bcccbd3a68";
			var authToken = "";
			TwilioClient.Init(accountSid, authToken);

			var repo = new QuoteRepo();
			var quote = repo.GetRandomQuote(user.UserId);
			var quoteBody = quote.QuoteBody;
			var author = quote.Author;
			var show = quote.Title;

			var appNumber = new PhoneNumber("+16154923369");
			var to = new PhoneNumber($"+1{user.Phone}");

			var message = MessageResource.Create(
				to,
				from: appNumber,
				body: $"'{quoteBody}' -{author} ({show})",
				pathAccountSid: accountSid);
		}
	}
}