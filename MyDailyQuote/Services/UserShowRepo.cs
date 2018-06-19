using Dapper;
using MyDailyQuote.Models;
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

		public List<UserShowDto> GetSubscriptionsByUser(int userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Query<UserShowDto>(@"Select *
											From [dbo].[UserShow] u
											Join [dbo].[Show] s
											On s.ShowId = u.ShowId
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

		public int SubscribeToShow(int userId, int showId)
		{
			using(var db = GetConnection())
			{
				db.Open();
				return db.Execute(@"Insert into [dbo].[UserShow]
									([ShowId],
									 [UserId])
								  Values
									(@showId,
									 @userId)", new { userId, showId });
			}
		}
	}
}