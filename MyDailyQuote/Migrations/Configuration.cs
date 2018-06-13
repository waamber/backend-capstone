namespace MyDailyQuote.Migrations
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using MyDailyQuote.Models;
	using MyDailyQuote.Services;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDailyQuote.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDailyQuote.Models.AppDbContext context)
        {

			var userManager = new ApplicationUserManager(new UserStore<User>(context));

			var user = new User
			{
				UserName = "waamber",
				Email = "testemail@email.com",
				FirstName = "amber",
				LastName = "stuart",
				Phone = "9313029448"
			};

			userManager.CreateAsync(user, "password").Wait();
		}
    }
}
