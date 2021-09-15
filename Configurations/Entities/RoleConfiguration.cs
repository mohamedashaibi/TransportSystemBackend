using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportSystem.Configurations.Entities
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Name = "Developer",
					NormalizedName = "DEVELOPER"
				},
				new IdentityRole
				{
					Name = "NormalUser",
					NormalizedName = "NORMALUSER"
				},
				new IdentityRole
				{
					Name = "BranchUser",
					NormalizedName = "BRANCHUSER"
				},
				new IdentityRole
				{
					Name = "CompanyUser",
					NormalizedName = "COMPANYUSER"
				},
				new IdentityRole
				{
					Name= "Administrator",
					NormalizedName="ADMINISTRATOR"
				}
				);
		}
	}
}
