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
	public class InvoiceProductsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public InvoiceProductsController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			var invoiceProducts = await _unitOfWork.InvoiceProductRepo.GetAll();

			var productsMap = _mapper.Map<IList<InvoiceProductDTO>>(invoiceProducts);

			return Ok(productsMap);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var invoiceProduct = await _unitOfWork.InvoiceProductRepo.Get(i => i.Id == id);

			if(invoiceProduct == null)
			{
				return NotFound();
			}

			var productMap = _mapper.Map<InvoiceProductDTO>(invoiceProduct);

			return Ok(productMap);
		}

		[HttpPost("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> AddProduct(int id, [FromBody]InvoiceProductDTO productDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var invoice = await _unitOfWork.InvoiceRepo.Get(i => i.Id == id);

			if(invoice == null)
			{
				return BadRequest("Invoice not found");
			}

			var product = _mapper.Map<InvoiceProduct>(productDTO);

			await _unitOfWork.InvoiceProductRepo.Create(product);

			await _unitOfWork.Save();

			var productMap = _mapper.Map<InvoiceProductDTO>(product);

			return Ok(productMap);
		}
	}
}
