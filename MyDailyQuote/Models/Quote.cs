using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class Quote
	{
		public virtual int QuoteId { get; set; }
		public virtual string QuoteBody { get; set; }
		public virtual string Author { get; set; }
		public virtual int ShowId { get; set; }
	}
}