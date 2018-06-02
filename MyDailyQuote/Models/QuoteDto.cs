using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class QuoteDto
	{
		public virtual string QuoteBody { get; set; }
		public virtual string Author { get; set; }
	}
}