using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Data;
using TransportSystem.IRepository;
using TransportSystem.Models;

namespace TransportSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InvoicesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			var invoices = await _unitOfWork.InvoiceRepo.GetAll(includes: new List<string> { "Company" });

			var invoicesMap = _mapper.Map<IList<InvoiceDTO>>(invoices);

			return Ok(invoicesMap);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var invoice = await _unitOfWork.InvoiceRepo.Get(i => i.Id == id, includes: new List<string> { "InvoiceProducts" });
		
			if(invoice == null)
			{
				return NotFound();
			}

			var invoiceMap = _mapper.Map<InvoiceDTO>(invoice);

			return Ok(invoiceMap);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var invoiceMap = _mapper.Map<Invoice>(invoiceDTO);

			await _unitOfWork.InvoiceRepo.Create(invoiceMap);

			await _unitOfWork.Save();

			var invoicesMap = _mapper.Map<InvoiceDTO>(invoiceMap);

			return Ok(invoicesMap);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceDTO invoiceDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			if(id != invoiceDTO.Id)
			{
				return BadRequest("Error in data");
			}

			var invoice = await _unitOfWork.InvoiceRepo.Get(i => i.Id == id);

			if(invoice == null)
			{
				return NotFound();
			}

			invoice.Information = invoiceDTO.Information;

			_unitOfWork.InvoiceRepo.Update(invoice);

			await _unitOfWork.Save();

			return Ok("Updated successfully");
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteInvoice(int id)
		{
			var invoice = await _unitOfWork.InvoiceRepo.Get(i => i.Id == id, includes: new List<string> { "InvoiceProducts" });

			if(invoice == null)
			{
				return NotFound();
			}

			if(invoice.InvoiceProducts != null)
			{
				return BadRequest("This invoice contains products, you cannot delete it");
			}

			await _unitOfWork.InvoiceRepo.Delete(id);

			await _unitOfWork.Save();

			return Ok("Deleted successfully");

		}
 	}
}
