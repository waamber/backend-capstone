﻿using MyDailyQuote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDailyQuote.Controllers
{
	[RoutePrefix("api/shows")]
	public class ShowController : ApiController
	{
		[Route(""), HttpGet]
		public HttpResponseMessage ListShows()
		{
			var repo = new ShowRepo();
			var result = repo.GetShows();

			return Request.CreateListRecordResponse(result);
		}

	}
}