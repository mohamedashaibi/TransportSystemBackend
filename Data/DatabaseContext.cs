using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TransportSystem.Data
{
	public class DatabaseContext : IdentityDbContext<ApiUser>
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{

		}
		//public DbSet<Country> Countries { get; set; }
		//public DbSet<Hotel> Hotels { get; set; }

		public DbSet<Branch> Branches { get; set; }
		public DbSet<BranchUser> BranchUsers { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<CompanyProduct> CompanyProducts { get; set; }
		public DbSet<CompanyUser> CompanyUsers { get; set; }
		public DbSet<DeveloperUser> DeveloperUsers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
		public DbSet<NormalUser> NormalUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new RoleConfiguration());
			builder.ApplyConfiguration(new CityConfiguration());

			//var hasher = new PasswordHasher<ApiUser>();
			//builder.Entity<ApiUser>().HasData(
			//	new ApiUser
			//	{
			//		Id = 1, // primary key
			//		UserName = "admin",
			//		NormalizedUserName = "ADMIN",
			//		PasswordHash = hasher.HashPassword(null, "temporarypass"),
					
			//	},
			//	new ApiUser
			//	{
			//		Id = 2, // primary key
			//		UserName = "staff",
			//		NormalizedUserName = "STAFF",
			//		PasswordHash = hasher.HashPassword(null, "temporarypass"),
					
			//	}
			//);

			//builder.Entity<IdentityUserRole<string>>().HasData(
			//	new IdentityUserRole<string>
			//	{
			//		RoleId = 1, // for admin username
			//		UserId = 1  // for admin role
			//	},
			//	new IdentityUserRole<string>
			//	{
			//		RoleId = 2, // for staff username
			//		UserId = 2  // for staff role
			//	}
			//);

		}

	}
}
