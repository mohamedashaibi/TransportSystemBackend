using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CreateCompanyProductDTO
	{
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public int CompanyId { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string EnglishName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string ArabicName { get; set; }
		public string Description { get; set; }
	}
	public class CompanyProductDTO : CreateCompanyProductDTO
	{
		public int Id { get; set; }
		
	}
}
