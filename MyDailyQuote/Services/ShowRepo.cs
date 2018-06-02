using MyDailyQuote.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;


namespace MyDailyQuote.Services
{
	public class ShowRepo
	{

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyDailyQuote"].ConnectionString);
		}

		public List<Show> GetShows()
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = "select * from dbo.Show";
				return db.Query<Show>(sql).ToList();
			}
		}
	}	
}