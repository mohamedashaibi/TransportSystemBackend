using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportSystem.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using TransportSystem.Models;

namespace TransportSystem
{
	public static class ServiceExtensions
	{
		public static void ConfigureIdentityServices(this IServiceCollection services)
		{
			var builder = services.AddIdentityCore<ApiUser>(u => u.User.RequireUniqueEmail = true);

			builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

			builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
		}

		public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
		{
			var jwtSettings = Configuration.GetSection("Jwt");
			var key = Environment.GetEnvironmentVariable("TransportSystemKey", EnvironmentVariableTarget.Machine);

			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuer = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwtSettings.GetSection("issuer").Value,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

				};
			});
		}
		public static void ConfigureVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(opt =>
			{
				opt.ReportApiVersions = true;
				opt.AssumeDefaultVersionWhenUnspecified = true;
				opt.DefaultApiVersion = new ApiVersion(1, 0);
				opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
			});
		}

		public static void ConfigureRateLimiting(this IServiceCollection services)
		{
			var rateLimitingRules = new List<RateLimitRule>
			{
				new RateLimitRule
				{
					Endpoint = "Api/*",
					Limit = 1,
					Period = "1s"
				}
			};

			services.Configure<IpRateLimitOptions>(opt =>
			{
				opt.GeneralRules = rateLimitingRules;
			});

			services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
			services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
			services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

		}
		public static void ConfigureExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(error =>
			{
				error.Run(async context =>
				{
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						Log.Error($"Something went wrong with {contextFeature.Error}");

						await context.Response.WriteAsync(new Error
						{
							StatusCode = context.Response.StatusCode,
							Message = "Internal server error."
						}.ToString());
					}
				});
			});
		}
	}
}
