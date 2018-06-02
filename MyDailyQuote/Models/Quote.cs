using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class Quote
	{
		public int QuoteId { get; set; }
		public string QuoteBody { get; set; }
		public string Author { get; set; }
		public int ShowId { get; set; }
	}
}