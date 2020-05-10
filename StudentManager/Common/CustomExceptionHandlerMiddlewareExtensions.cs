using Microsoft.AspNetCore.Builder;

namespace StudentManager.API.Common
{
	/// <summary>
	/// Custom exception handler middleware extension
	/// </summary>
	public static class CustomExceptionHandlerMiddlewareExtensions
	{
		/// <summary>
		/// Extenstion method
		/// </summary>
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
		}
	}
}