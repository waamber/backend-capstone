﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Models
{
	public class User
	{
		public virtual int UserId { get; set; }
		public virtual string Email { get; set; }
		public virtual string Password { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Phone { get; set; }
	}
}