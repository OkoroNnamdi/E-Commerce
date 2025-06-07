using E_Commerce.DB;
using E_Commerce.DB.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_commerce.Api.Extension
{
	public static  class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("DBConnection")));

			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
