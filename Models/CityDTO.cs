using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CreateCityDTO
	{
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string EnglishName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string ArabicName { get; set; }
	}
	public class CityDTO : CreateCityDTO
	{
		public int Id { get; set; }
		
	}
}
