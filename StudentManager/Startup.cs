using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Converters;
using StudentManager.API.Common;
using StudentManager.Application;
using StudentManager.EF;

namespace StudentManager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEf(Configuration);
			services.AddApplication();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Student manager",
					Version = "v1"
				});

				var docFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var docFilePath = Path.Combine(AppContext.BaseDirectory, docFile);

				c.IncludeXmlComments(docFilePath);
			});

			services.AddControllers().AddNewtonsoftJson(options =>
				options.SerializerSettings.ContractResolver = new DefaultContractResolver()); 
			services.AddControllers().AddNewtonsoftJson(options => 
				options.SerializerSettings.Converters.Add(new StringEnumConverter()));
			services.AddDbContext<StudentManagerContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Manager API");
				c.RoutePrefix = "swagger";
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCustomExceptionHandler();

			app.UseCors(options => 
				options.WithOrigins("http://localhost:4200")
					.AllowAnyMethod()
					.AllowAnyHeader());

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
