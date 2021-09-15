using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class DeveloperUser
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public double Balance { get; set; }
		public bool Status { get; set; }

		public ApiUser ApiUser { get; set; }
	}
}
