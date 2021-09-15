using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CompanyUserDTO
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public Guid ApiUserId { get; set; }
		public bool Status { get; set; }
	}
}
