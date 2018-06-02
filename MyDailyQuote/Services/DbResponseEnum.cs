using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDailyQuote.Services
{
	public enum DbResponseEnum
	{
		Created,
		NotCreated,
		RecordsCreated,
		RecordsReturned,
		Updated,
		NotFound,
		ValidationError,
		Success
	}
}