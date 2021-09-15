using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class DeveloperUserDTO
	{
		public int Id { get; set; }
		public Guid ApiUserId { get; set; }
		public string Name { get; set; }
		public double Balance { get; set; }
		public bool Status { get; set; }
	}
}
