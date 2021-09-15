using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportSystem.Data;

namespace TransportSystem.Configurations.Entities
{
	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasData(
				new City
				{
					Id = 1,
					ArabicName = "طرابلس",
					EnglishName = "Tripoli"
				},
				new City
				{
					Id = 2,
					ArabicName = "بنغازي",
					EnglishName = "Benghazi"
				}
				);
		}
	}
}
