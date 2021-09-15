using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{

	public class GetUserDTO
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }

	}
	public class UserLoginDTO
	{

		[Required(ErrorMessage = "This field is required!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(15, ErrorMessage = "This field is limited to {2} to {1} characters", MinimumLength = 10)]
		public string Password { get; set; }
	}

	public class UserSignupDTO : UserLoginDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		public ICollection<string> Roles { get; set; }

	}
	public class UserDTO : UserSignupDTO
	{
		public string Id { get; set; }
 
	}
}
