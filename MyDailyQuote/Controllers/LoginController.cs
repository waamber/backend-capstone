using MyDailyQuote.Services;
using System.Net.Http;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{

	[RoutePrefix("api/login")]
	public class LoginController : ApiController
	{
		[Route("{password}"), HttpGet]
		public HttpResponseMessage LoginUser(string password)
		{
			var repo = new LoginRepo();
			var result = repo.GetUserByPassword(password);

			return Request.CreateResponse(result);
		}
	}

}