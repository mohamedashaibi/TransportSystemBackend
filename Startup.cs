using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Configurations;
using TransportSystem.Data;
using TransportSystem.IRepository;
using TransportSystem.Repository;
using TransportSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace TransportSystem
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(options=>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
			});

			services.ConfigureRateLimiting();

			services.AddHttpContextAccessor();

			services.AddMemoryCache();

			services.ConfigureVersioning();

			services.AddAuthentication();

			services.ConfigureIdentityServices();

			services.ConfigureJWT(Configuration);

			services.AddCors(o=>
			{
				o.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin();
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
				});
			});

			services.AddTransient<IUnitOfWork, UnitOfWork>();

			services.AddAutoMapper(typeof(MapperInitializer));

			services.AddScoped<IAuthManager, AuthManager>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransportSystem", Version = "v1" });
			});
			services.AddControllers().AddNewtonsoftJson(op =>
			{
				op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransportSystem v1"));
			}

			app.UseHttpsRedirection();

			app.UseCors("AllowAll");

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
