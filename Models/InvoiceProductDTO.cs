using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{

	public class CreateInvoiceProductDTO
	{
		public int CompanyProductId { get; set; }
		public int InvoiceId { get; set; }
		public float Quantity { get; set; }
	}
	public class UpdateInvoiceProductDTO : CreateInvoiceProductDTO
	{
		public int Id { get; set; }

	}

	public class InvoiceProductDTO : UpdateInvoiceProductDTO
	{
	
		public int Status { get; set; }
	}
}
