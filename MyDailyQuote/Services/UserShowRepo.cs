using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Services
{
	public class UserShowRepo
	{
		public static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyDailyQuote"].ConnectionString);
		}

		public List<UserShow> GetSubscriptionsByUser(int userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Query<UserShow>(@"Select *
											From [dbo].[UserShow] u
											Where u.UserId = @userId", new { userId }).ToList();

			}
		}

		public int UnsubscribeUserToShow(int userId, int showId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Execute(@"Delete from UserShow
									Where UserId = @userId
									And ShowId = @showId", new { userId, showId });
			}
		}
	}
}