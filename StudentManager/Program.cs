using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StudentManager.API
{
	/// <summary/>
	public class Program
	{
		/// <summary/>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary/>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
