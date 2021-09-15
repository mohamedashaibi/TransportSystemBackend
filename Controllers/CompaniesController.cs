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
	public class CompaniesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public CompaniesController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			var companies = await _unitOfWork.CompanyRepo.GetAll();

			var companiesMap = _mapper.Map<IList<CompanyDTO>>(companies);

			return Ok(companiesMap);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var company = await _unitOfWork.CompanyRepo.Get(c => c.Id == id);

			if(company == null)
			{
				return NotFound();
			}

			var companyMap = _mapper.Map<CompanyDTO>(company);

			return Ok(companyMap);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDTO companyDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var company = _mapper.Map<Company>(companyDTO);

			company.Status = true;

			await _unitOfWork.CompanyRepo.Create(company);

			await _unitOfWork.Save();

			var companyMap = _mapper.Map<CompanyDTO>(company);

			return Ok(companyMap);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyDTO companyDTO)
		{
			
			if(id != companyDTO.Id)
			{
				return BadRequest("Error in data");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var company = await _unitOfWork.CompanyRepo.Get(c => c.Id == id);

			if(company == null)
			{
				return BadRequest("No company found.");
			}

			company.Address = companyDTO.Address;
			company.ArabicName = companyDTO.ArabicName;
			company.EnglishName = companyDTO.EnglishName;
			company.PhoneNumber = companyDTO.PhoneNumber;

			_unitOfWork.CompanyRepo.Update(company);

			await _unitOfWork.Save();

			var companyMap = _mapper.Map<CompanyDTO>(company);

			return Ok(companyMap);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DisableBranch(int id)
		{
			var company = await _unitOfWork.CompanyRepo.Get(b => b.Id == id);

			if (company == null)
			{
				return NotFound();
			}

			company.Status = false;

			_unitOfWork.CompanyRepo.Update(company);

			await _unitOfWork.Save();

			return Ok();
		}

		[HttpPatch("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> EnableCompany(int id)
		{
			var company = await _unitOfWork.CompanyRepo.Get(b => b.Id == id);
			if (company == null)
			{
				return NotFound();
			}

			if (company.Status == true)
			{
				return Ok("This company is already enabled");
			}

			company.Status = true;

			_unitOfWork.CompanyRepo.Update(company);

			await _unitOfWork.Save();

			return Ok("Enabled successfully");
		}

	}
}
