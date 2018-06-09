using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class UserShowDto
	{
		public int UserId { get; set; }
		public int ShowId { get; set; }
		public string Title { get; set; }
	}
}