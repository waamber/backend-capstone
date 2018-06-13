using Microsoft.AspNet.Identity.EntityFramework;
using MyDailyQuote.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyDailyQuote.Models
{
	public class User : IdentityUser
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Phone { get; set; }
		
		

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, string authenticationType)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			// Add custom user claims here
			return userIdentity;
		}
	}
}