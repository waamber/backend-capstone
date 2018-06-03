using MyDailyQuote.Models;
using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/users")]
	public class UserController : ApiController
	{
		[Route(""), HttpGet]
		public HttpResponseMessage GetUsers()
		{
			var repo = new UserRepo();
			var result = repo.GetUsers();

			return Request.CreateListRecordResponse(result);
		}

		[Route("{userId}"), HttpGet]
		public HttpResponseMessage GetUserById(int userId)
		{
			var repo = new UserRepo();
			var result = repo.GetUser(userId);

			return Request.CreateResponse(result);
		}
	}
}