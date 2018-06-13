using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(MyDailyQuote.Startup))]

namespace MyDailyQuote
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			GlobalConfiguration.Configuration.UseSqlServerStorage("MyDailyQuote");
			app.UseHangfireDashboard();
			app.UseHangfireServer();
			ConfigureAuth(app);
		}
	}
}
