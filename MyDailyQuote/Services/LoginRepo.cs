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
	public class LoginRepo
	{
		private static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyDailyQuote"].ConnectionString);
		}

		public User GetUserByPassword(string password)
		{
			using (var db = GetConnection())
			{
				db.Open();

				return db.QueryFirst<User>(@"select * 
											from[dbo].[user]
											where Password = @password", new { password });
			}
		}

		public int CreateNewUser(UserDto user)
		{
			using (var db= GetConnection())
			{
				db.Open();

				return db.Execute(@"Insert into [dbo].[user]
									([FirstName],
									 [LastName],
									 [Phone],
									 [Username],
									 [Password])
									Values
									 (@FirstName,
									  @LastName,
									  @Phone, 
									  @Username.
									  @Password)");
			}
		}
	}
}