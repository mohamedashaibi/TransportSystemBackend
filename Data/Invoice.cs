using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportSystem.Data
{
	public class Invoice
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateFinished { get; set; }
		//NormalUser id
		public int NormalUserId { get; set; }
		public Guid CreatedById { get; set; }
		public bool Status { get; set; }
		public string Information { get; set; }
		public int CompanyId { get; set; }


		public IList<InvoiceProduct> InvoiceProducts { get; set; }
		public Company Company { get; set; }
		public ApiUser CreateBy { get; set; }
		public NormalUser NormalUser { get; set; }
	}
}
