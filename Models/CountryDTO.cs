//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TransportSystem.Models
//{
	
//	public class CreateCountryDTO
//	{
//		[Required(ErrorMessage = "This field is required.")]
//		[StringLength(maximumLength: 50, ErrorMessage = "The name is too long.(mx is 50 letters)")]
//		public string Name { get; set; }
//		[Required(ErrorMessage = "This field is required.")]
//		[StringLength(maximumLength: 2, ErrorMessage = "The name is too long.(mx is 2 letters)")]
//		public string ShortName { get; set; }
//	}
//	public class CountryDTO : CreateCountryDTO
//	{
//		public int Id { get; set; }

//		public IList<HotelDTO> Hotels { get; set; }

//	}
//}
