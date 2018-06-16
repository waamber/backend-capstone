using MyDailyQuote.Services;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{

	[RoutePrefix("api/login/{password}")]
	public class LoginController : ApiController
	{
		[Route(""), HttpGet]
		public HttpResponseMessage LoginUser(string password)
		{
			var repo = new LoginRepo();
			var result = repo.GetUserByPassword(password);

			return Request.CreateResponse(result);
		}
	}
		
	
}