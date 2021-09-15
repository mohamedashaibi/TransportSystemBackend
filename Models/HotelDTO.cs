//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TransportSystem.Models
//{
	
//	public class CreateHotelDTO
//	{
//		[Required(ErrorMessage = "This field is required.")]
//		[StringLength(maximumLength: 50, ErrorMessage = "The name is too long.(mx is 50 letters)")]
//		public string Name { get; set; }
//		public int CountriId { get; set; }
//	}
//	public class HotelDTO : CreateHotelDTO
//	{
//		public int Id { get; set; }
//		public CountryDTO Country { get; set; }
//	}
//}
