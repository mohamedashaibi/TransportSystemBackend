using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class Branch
	{
		public int Id { get; set; }
		public string EnglishName { get; set; }
		public string ArabicName { get; set; }
		public int CityId { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public bool Status { get; set; }

		public City City { get; set; }
		public IList<BranchUser> BranchUsers { get; set; }
	}
}
