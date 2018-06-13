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
	public class QuoteRepo
	{
		public static SqlConnection GetConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["MyDailyQuote"].ConnectionString);
		}

		public List<Quote> GetQuotes()
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = "Select * From [dbo].[Quote]";
				return db.Query<Quote>(sql).ToList();
			}
		}

		public QuoteDto GetRandomQuote(string userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = @"select top 1 s.Title, q.quotebody, q.Author
						   from[dbo].[AspNetUser] u
						   join usershow x
						   on x.UserId = u.Id
						   join show s
						   on x.ShowId = s.ShowId
						   join[dbo].[quote] q
						   on q.ShowId = x.ShowId
						   where u.Id = @userId
						   order by newid()";

				return db.QueryFirst<QuoteDto>(sql, new { userId });
			}
		}

		public int CreateQuote(Quote quote)
		{
			using (var db = GetConnection())
			{
				db.Open();
				return db.Execute(@"insert into quote
											([QuoteBody]
											,[Author]
											,[ShowId])
										values
											(@QuoteBody
											,@Author
											,@ShowId)", quote);
			}
		}

	}
}