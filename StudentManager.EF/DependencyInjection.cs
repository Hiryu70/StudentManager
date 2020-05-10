using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManager.Application.Common.Interfaces;

namespace StudentManager.EF
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddEf(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<StudentManagerContext>(options =>
				options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

			services.AddScoped<IStudentManagerContext>(provider => provider.GetService<StudentManagerContext>());

			return services;
		}
	}
}
