using MyDailyQuote.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;

namespace MyDailyQuote.Services
{
	public class UserRepo
	{
		public static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyDailyQuote"].ConnectionString);
		}

		public List<User> GetUsers()
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = "Select * From [dbo].[User]";
				return db.Query<User>(sql).ToList();
			}
		}

		public UserDto GetUser(int userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.QueryFirst<UserDto>(@"Select u.FirstName, u.LastName, u.Email, u.Phone
									   From [dbo].[User] u
									   Where u.UserId = @userId", new { userId });
			}
		}

		public int UpdateUser(User user)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Execute(@"Update [dbo].[User]
									Set [LastName] = @LastName,
										[Phone] = @Phone
									Where UserId = @UserId", user);
			}
		}

	}
}