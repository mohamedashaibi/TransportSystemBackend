using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class NormalUser
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public string Address { get; set; }
		public bool Status { get; set; }

		public ApiUser ApiUser { get; set; }
	}
}
