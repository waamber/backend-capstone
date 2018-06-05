using Hangfire;
using MyDailyQuote.Controllers;
using MyDailyQuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Services
{
	public class QuoteScheduler
	{
		public void SendOutDailyQuote(User user)
		{
			var repo = new SmsController();

			RecurringJob.AddOrUpdate("SendDailyText", () => repo.SendQuote(user), "0 12 * * *");
		}
	}
}