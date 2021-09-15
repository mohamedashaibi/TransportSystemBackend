using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CreateCompanyDTO
	{
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string EnglishName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string ArabicName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string Address { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string PhoneNumber { get; set; }
	}

	public class UpdateCompanyDTO : CreateCompanyDTO
	{
		public int Id { get; set; }
	}
	public class CompanyDTO : UpdateCompanyDTO
	{
		public bool Status { get; set; }

	}
}
