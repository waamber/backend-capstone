using Microsoft.AspNet.Identity;
using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/subscriptions")]
	public class SubscriptionController : ApiController
	{

		[Route("{userId}"), HttpGet]
		public HttpResponseMessage GetSubscriptionsByUser(int userId)
		{
			var repo = new UserShowRepo();
			var result = repo.GetSubscriptionsByUser(userId);

			return Request.CreateListRecordResponse(result);
		}

		[Route("unsubscribe/{userId}/{showId}"), HttpDelete]
		public HttpResponseMessage UnsubscribeToShow([FromUri]int userId, int showId)
		{
			var repo = new UserShowRepo();
			var subscriptions = repo.GetSubscriptionsByUser(userId);
			
			foreach(var subscription in subscriptions)
			{
				if(subscription.ShowId == showId)
				{
					subscription.ShowId = showId;
				}
			}

			var result = repo.UnsubscribeUserToShow(userId, showId);

			return Request.CreateUpdatedRecordResponse(result);
		}

		[Route("subscribe/{userId}/{showId}"), HttpPost]
		public HttpResponseMessage SubscribeToShow(int userId, int showId)
		{
			var repo = new UserShowRepo();
			var result = repo.SubscribeToShow(userId, showId);

			return Request.CreateAddRecordResponse(result);
		}
	}
}