using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
	public class CompanyProductsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CompanyProductsController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetProducts")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{

			if (User.IsInRole("Administrator"))
			{
				var productsList = await _unitOfWork.CompanyProductRepo.GetAll();

				var productsMapp = _mapper.Map<IList<CompanyProductDTO>>(productsList);

				return Ok(productsMapp);
			}

			var userId = User.Claims.First(u => u.Type == ClaimTypes.PrimarySid);

			if(userId == null)
			{
				return NotFound();
			}

			var company = await _unitOfWork.CompanyUser.Get(c => c.ApiUserId.ToString() == userId.Value);
			
			if(company == null)
			{
				return NotFound();
			}

			var products = await _unitOfWork.CompanyProductRepo.GetAll(c => c.CompanyId == company.CompanyId);

			var productsMap = _mapper.Map<IList<CompanyProductDTO>>(products);

			return Ok(productsMap);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var product = await _unitOfWork.CompanyProductRepo.Get(c => c.Id == id);

			if(product == null)
			{
				return NotFound();
			}

			var productMap = _mapper.Map<CompanyProductDTO>(product);

			return Ok(product);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateProduct([FromBody] CreateCompanyProductDTO productDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var product = _mapper.Map<CompanyProduct>(productDTO);

			await _unitOfWork.CompanyProductRepo.Create(product);

			await _unitOfWork.Save();

			var productMap = _mapper.Map<CompanyProductDTO>(product);

			return Ok(productMap);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateCompanyProduct(int id, [FromBody] CompanyProductDTO companyProductDTO)
		{
			if (id != companyProductDTO.Id)
			{
				return BadRequest("Error in data");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var companyProduct = await _unitOfWork.CompanyProductRepo.Get(c => c.Id == id);

			if (companyProduct == null)
			{
				return NotFound();
			}

			companyProduct.Description = companyProductDTO.Description;
			companyProduct.ArabicName = companyProductDTO.ArabicName;
			companyProduct.EnglishName = companyProductDTO.EnglishName;

			_unitOfWork.CompanyProductRepo.Update(companyProduct);

			await _unitOfWork.Save();

			var productMap = _mapper.Map<CompanyProductDTO>(companyProduct);

			return Ok(productMap);
		}


	}
}
