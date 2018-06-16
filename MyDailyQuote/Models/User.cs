using Microsoft.AspNet.Identity.EntityFramework;
using MyDailyQuote.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyDailyQuote.Models
{
	public class User 
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Phone { get; set; }
		public virtual int UserId { get; set; }
		public virtual string Password { get; set; }
		public virtual string Username { get; set; }
	
	}
}