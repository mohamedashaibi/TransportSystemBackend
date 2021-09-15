using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class NormalUserDTO
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public bool Status { get; set; }

	}
}
