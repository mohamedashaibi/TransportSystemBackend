using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class Company
	{
		public int Id { get; set; }
		public string EnglishName { get; set; }
		public string ArabicName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public int CityId { get; set; }
		public bool Status { get; set; }

		public IList<CompanyUser> CompanyUsers { get; set; }
		public IList<CompanyProduct> CompanyProducts { get; set; }

	}
}
