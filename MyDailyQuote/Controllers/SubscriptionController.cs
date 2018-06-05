using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/subscription")]
	public class SubscriptionController : ApiController
	{

		[Route("{userId}"), HttpGet]
		public HttpResponseMessage GetSubscriptionsByUser(int userId)
		{
			var repo = new UserShowRepo();
			var result = repo.GetSubscriptionsByUser(userId);

			return Request.CreateListRecordResponse(result);
		}

		//[Route("unsubscribe"), HttpDelete]
		//public HttpResponseMessage UnsubscribeToShow(int userId)
		//{
		//	var 
		//	var userShowRepo = new UserShowRepo();

		//	var result = repo.UnsubscribeUserToShow(userId, showId);

		//	return Request.CreateUpdatedRecordResponse(result);
		//}
	}
}