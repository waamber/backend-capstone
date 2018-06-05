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
			var authToken = "e675ff86ce775423fec786a144af25d0";
			TwilioClient.Init(accountSid, authToken);

			var repo = new QuoteRepo();
			var quote = repo.GetRandomQuote(user.UserId).QuoteBody.ToString();
			var author = repo.GetRandomQuote(user.UserId).Author.ToString();
			var show = repo.GetRandomQuote(user.UserId).Title.ToString();

			var appNumber = new PhoneNumber("+16154923369");
			var to = new PhoneNumber($"+1{user.Phone}");

			var message = MessageResource.Create(
				to,
				from: appNumber,
				body: $"'{quote}' -{author} ({show})",
				pathAccountSid: accountSid);
		}
	}
}