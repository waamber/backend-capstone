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
				var sql = "select * from dbo.Quote";
				return db.Query<Quote>(sql).ToList();
			}
		}

		public QuoteDto GetRandomQuote(int userId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = @"select top 1 s.Title, q.quotebody, q.Author
						   from[dbo].[User] u
						   join usershow x
						   on x.UserId = u.UserId
						   join show s
						   on x.ShowId = s.ShowId
						   join[dbo].[quote] q
						   on q.ShowId = x.ShowId
						   where u.userId = @userId
						   order by newid()";

				return db.QueryFirst<QuoteDto>(sql, new { userId });
			}
		}

		public bool CreateQuote(Quote quote, Show showId)
		{
			using (var db = GetConnection())
			{
				db.Open();
				var sql = db.Execute(@"insert into quote
											([QuoteBody]
											, [Author]
											,[ShowId]))
										values
											([@quote.QuoteBody]
											,[@quote.Author]
											,[@showId])", quote);

				return sql == 1;
			}
		}

	}
}