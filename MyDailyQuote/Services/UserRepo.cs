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
				var sql = "Select * From [dbo].[AspNetUsers]";
				return db.Query<User>(sql).ToList();
			}
		}

		public UserDto GetUser(string userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.QueryFirst<UserDto>(@"Select u.FirstName, u.LastName, u.Email, u.Phone
									   From [dbo].[AspNetUsers] u
									   Where u.Id = @userId", new { userId });
			}
		}

		public User GetUserById(string userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.QueryFirst<User>(@"Select u.FirstName, u.LastName, u.Email, u.Phone
									   From [dbo].[AspNetUsers] u
									   Where u.Id = @userId");
			}
		}

		public int UpdateUser(User user)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Execute(@"Update [dbo].[AspNetUsers]
									Set [LastName] = @LastName,
										[Phone] = @Phone
									Where Id = @UserId", user);
			}
		}

	}
}