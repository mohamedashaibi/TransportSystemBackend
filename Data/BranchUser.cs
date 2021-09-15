using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class BranchUser
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public int BranchId { get; set; }
		public bool Status { get; set; }

		public Branch Branch { get; set; }
		public ApiUser ApiUser { get; set; }
	}
}
