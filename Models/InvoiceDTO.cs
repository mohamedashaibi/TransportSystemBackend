using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Models
{
	public class CreateInvoiceDTO
	{
		public DateTime DateCreated { get; set; }
		public DateTime? DateFinished { get; set; }
		public int NormalUserId { get; set; }
		public Guid CreatedById { get; set; }
		public string Information { get; set; }
	}

	public class UpdateInvoiceDTO : CreateInvoiceDTO
	{
		public int Id { get; set; }
	}
	public class InvoiceDTO : UpdateInvoiceDTO
	{
		public bool Status { get; set; }
	}
}
