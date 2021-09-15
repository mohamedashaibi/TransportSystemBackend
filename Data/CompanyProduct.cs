using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class CompanyProduct
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string EnglishName { get; set; }
		public string ArabicName { get; set; }
		public string Description { get; set; }

		public Company Company { get; set; }

	}
}
