using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class CompanyUser
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public Guid ApiUserId { get; set; }
		public bool Status { get; set; }

		public Company Company { get; set; }
		public ApiUser ApiUser { get; set; }
	}
}
