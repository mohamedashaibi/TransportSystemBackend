using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Data;
using TransportSystem.IRepository;
using TransportSystem.Models;

namespace TransportSystem.Controllers
{
	//[Authorize(Roles = "Administrator")]
	[Route("api/[controller]")]
	[ApiController]
	public class CitiesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfwork;
		private readonly IMapper _mapper;

		public CitiesController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfwork = unitOfWork;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			var cities = await _unitOfwork.CityRepo.GetAll();

			var cityMap = _mapper.Map<IList<CityDTO>>(cities);

			return Ok(cityMap);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var city = await _unitOfwork.CityRepo.Get(c => c.Id == id);
			
			if(city == null)
			{
				return NotFound();
			}

			var cityMap = _mapper.Map<CityDTO>(city);

			return Ok(cityMap);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateCity([FromBody] CreateCityDTO cityDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			var city = _mapper.Map<City>(cityDTO);

			await _unitOfwork.CityRepo.Create(city);

			await _unitOfwork.Save();

			var cityMap = _mapper.Map<CityDTO>(city);

			return Ok(cityMap);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDTO cityDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			if (id != cityDTO.Id)
			{
				return BadRequest("Error in data");
			}

			var city = await _unitOfwork.CityRepo.Get(b => b.Id == id);

			if (city == null)
			{
				return NotFound();
			}

			city.ArabicName = cityDTO.ArabicName;
			city.EnglishName = cityDTO.EnglishName;
			
			_unitOfwork.CityRepo.Update(city);

			await _unitOfwork.Save();

			return Ok("Updated successfully");
		}
	}
}
