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
				var sql = "select * from [dbo].[User]";
				return db.Query<User>(sql).ToList();
			}
		}
	}
}