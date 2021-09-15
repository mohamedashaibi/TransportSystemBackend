using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class InvoiceProduct
	{
		public int Id { get; set; }
		public int CompanyProductId { get; set; }
		public int InvoiceId { get; set; }
		public float Quantity { get; set; }
		public int Status { get; set; }
		public string Information { get; set; }
		public float Price { get; set; }

		public CompanyProduct CompanyProduct { get; set; }
		public Invoice Invoice { get; set; }
	}
}
