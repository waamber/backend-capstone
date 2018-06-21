using MyDailyQuote.Models;
using MyDailyQuote.Services;
using System.Net.Http;
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

		[Route("update/{userId}"), HttpPut]
		public HttpResponseMessage UpdateUser(User user, int userId )
		{
			user.UserId = userId;
			var repo = new UserRepo();
			var result = repo.UpdateUser(user);

			return Request.CreateUpdatedRecordResponse(result);
		}

		[Route("create"), HttpPost]
		public HttpResponseMessage CreateUser(UserDto user)
		{
			var repo = new UserRepo();
			var results = repo.CreateNewUser(user);

			return Request.CreateAddRecordResponse(results);
		}
	}
}
