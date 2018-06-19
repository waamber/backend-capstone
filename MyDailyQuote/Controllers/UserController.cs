using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{
		[Route("{userId}"), HttpGet]
		public HttpResponseMessage GetUser(int userId)
		{
			var repo = new UserRepo();
			var result = repo.GetUser(userId);

			return Request.CreateResponse(result);
		}
	}

}
