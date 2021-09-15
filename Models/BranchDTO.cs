using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CreateBranchDTO
	{
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string EnglishName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string ArabicName { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public int CityId { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string Address { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "هذا الحقل مطلوب")]
		public string Email { get; set; }
	}

	public class UpdateBranchDTO : CreateBranchDTO
	{
		public int Id { get; set; }
	}

	public class BranchDTO : UpdateBranchDTO
	{
		public bool Status { get; set; }
	}
}
