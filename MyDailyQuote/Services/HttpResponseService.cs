using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace MyDailyQuote.Services
{
	public static class HttpResponseService
	{
		//Status Responses
		private static HttpResponseMessage MapHttpResponse(this HttpRequestMessage message, DbResponseEnum dbResponse)
		{
			switch (dbResponse)
			{
				case DbResponseEnum.Created:
					return message.CreateResponse(HttpStatusCode.Created);
				case DbResponseEnum.NotCreated:
					return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "The record could not be created. Please try again.");
				case DbResponseEnum.Updated:
					return message.CreateResponse(HttpStatusCode.OK);
				case DbResponseEnum.NotFound:
					return message.CreateErrorResponse(HttpStatusCode.NotFound, "The record requested could not be found.");
				case DbResponseEnum.ValidationError:
					return message.CreateErrorResponse(HttpStatusCode.BadRequest, "A validation error has occured, please ensure that your data is correct.");
				default:
					return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "There was an unidentified error, my bad.");
			}
		}

		//Records Returned/Not Found Messages
		private static HttpResponseMessage MapHttpResponse<T>(this HttpRequestMessage message, DbResponseEnum dbResponse, IEnumerable<T> records)
		{
			switch (dbResponse)
			{
				case DbResponseEnum.RecordsReturned:
					return message.CreateResponse(HttpStatusCode.OK, records);
				case DbResponseEnum.NotFound:
					return message.CreateErrorResponse(HttpStatusCode.NotFound, "No records found.");
				default:
					return message.CreateErrorResponse(HttpStatusCode.InternalServerError, "There was an unidentified error, my bad");
			}
		}

		//Create Error Responses
		public static HttpResponseMessage CreateAddRecordResponse(this HttpRequestMessage message, int dbResult)
		{
			return dbResult == 1 ? message.MapHttpResponse(DbResponseEnum.Created) : message.MapHttpResponse(DbResponseEnum.NotCreated);
		}

		//Update Error Responses
		public static HttpResponseMessage CreateUpdatedRecordResponse(this HttpRequestMessage message, int dbResult)
		{
			if (dbResult > -1)
			{
				return dbResult == 1 ? message.MapHttpResponse(DbResponseEnum.Updated) : message.MapHttpResponse(DbResponseEnum.NotFound);
			}
			return message.MapHttpResponse(DbResponseEnum.ValidationError);
		}

		//List Not Found Response
		public static HttpResponseMessage CreateListRecordResponse<T>(this HttpRequestMessage message, List<T> dbResult)
		{
			return (dbResult.Count >= 0) ? message.MapHttpResponse(DbResponseEnum.RecordsReturned, dbResult) : message.MapHttpResponse(DbResponseEnum.NotFound);
		}

	}
}