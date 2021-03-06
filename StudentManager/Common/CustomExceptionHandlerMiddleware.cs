﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StudentManager.Application.Common.Exceptions;

namespace StudentManager.API.Common
{
	/// <summary>
	/// Middleware for exception handling
	/// </summary>
	public class CustomExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		/// <inheritdoc />
		public CustomExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// Execute middleware logic
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = HttpStatusCode.InternalServerError;

			var result = string.Empty;

			switch (exception)
			{
				case ValidationException validationException:
					code = HttpStatusCode.BadRequest;
					result = JsonConvert.SerializeObject(validationException.Failures);
					break;
				case NotFoundException _:
					code = HttpStatusCode.NotFound;
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) code;

			if (result == string.Empty)
			{
				result = JsonConvert.SerializeObject(new {error = exception.Message});
			}

			return context.Response.WriteAsync(result);
		}
	}
}
