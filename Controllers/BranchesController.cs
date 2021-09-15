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
using TransportSystem.Repository;

namespace TransportSystem.Controllers
{
	//[Authorize(Roles = "Administrator")]
	[Route("api/[controller]")]
	[ApiController]
	public class BranchesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public BranchesController(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet(Name = "GetBranches")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			var branches = await _unitOfWork.BranchRepo.GetAll();

			var branchesMap = _mapper.Map<IList<BranchDTO>>(branches);

			return Ok(branchesMap);
		}

		[HttpGet("{id:int}", Name = "GetBranch")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetOne(int id)
		{
			var branch = await _unitOfWork.BranchRepo.Get(b => b.Id == id);

			if (branch == null)
			{
				return NotFound();
			}

			var branchMap = _mapper.Map<BranchDTO>(branch);

			return Ok(branchMap);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateBranch([FromBody]CreateBranchDTO branchDTO)
		{
			if (!ModelState.IsValid) {
				return BadRequest("Error in data");
			}
			var branchModel = _mapper.Map<Branch>(branchDTO);

			branchModel.Status = true;

			await _unitOfWork.BranchRepo.Create(branchModel);

			await _unitOfWork.Save();

			var branchMap = _mapper.Map<BranchDTO>(branchModel);

			return Ok(branchMap);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateBranch(int id, [FromBody]UpdateBranchDTO branchDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid data");
			}

			if (id != branchDTO.Id)
			{
				return BadRequest("Error in data");
			}

			var branch = await _unitOfWork.BranchRepo.Get(b => b.Id == id);

			if (branch == null)
			{
				return NotFound();
			}

			branch.ArabicName = branchDTO.ArabicName;
			branch.EnglishName = branchDTO.EnglishName;
			branch.Email = branchDTO.Email;
			branch.PhoneNumber = branchDTO.PhoneNumber;
			branch.Address = branchDTO.Address;

			_unitOfWork.BranchRepo.Update(branch);

			await _unitOfWork.Save();

			return Ok("Updated successfully");
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DisableBranch(int id)
		{
			var branch = await _unitOfWork.BranchRepo.Get(b => b.Id == id);

			if(branch == null)
			{
				return NotFound();
			}

			branch.Status = false;

			_unitOfWork.BranchRepo.Update(branch);

			await _unitOfWork.Save();

			return Ok();
		}

		[HttpPatch("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> EnableBranch(int id)
		{
			var branch = await _unitOfWork.BranchRepo.Get(b => b.Id == id);
			if(branch == null)
			{
				return NotFound();
			}

			if(branch.Status == true)
			{
				return Ok("This branch is already enabled");
			}

			branch.Status = true;

			_unitOfWork.BranchRepo.Update(branch);

			await _unitOfWork.Save();

			return Ok("Enabled successfully");
		}
	}
}
