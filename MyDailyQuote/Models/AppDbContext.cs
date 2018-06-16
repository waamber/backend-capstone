using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("MyDailyQuote") { }
		
		public virtual DbSet<Quote> Quotes { get; set; }
		public virtual DbSet<Show> Shows { get; set; }

		internal static AppDbContext Create()
		{
			return new AppDbContext();
		}
	}
}