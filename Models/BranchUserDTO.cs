using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class BranchUserDTO
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public int BranchId { get; set; }
		public bool Status { get; set; }
	}
}
