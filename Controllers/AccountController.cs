using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TransportSystem.Data;
using TransportSystem.Models;
using TransportSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransportSystem.IRepository;

namespace TransportSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{

		private readonly UserManager<ApiUser> _userManager;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly IAuthManager _authManager;
		private readonly IUnitOfWork _unitOfWork;

		public AccountController(UserManager<ApiUser> userManager,
			IMapper mapper, ILogger<AccountController> logger,
			IAuthManager authManager, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_mapper = mapper;
			_logger = logger;
			_authManager = authManager;

		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] UserSignupDTO userDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = _mapper.Map<ApiUser>(userDTO);
			user.UserName = userDTO.Email;
			var result = await _userManager.CreateAsync(user, userDTO.Password);
			if (!result.Succeeded)
			{
				_logger.LogError("Something went wrong in the registration.");
				string errors = "";
				foreach(var item in result.Errors)
				{
					errors += item.Description + "//" + item.Code + "\n";
				}
				_logger.LogError(errors);

				return BadRequest("Something went wrong when registering.");
			}
			await _userManager.AddToRolesAsync(user, userDTO.Roles);
			return Ok("User Created Successfully!");
		}

		[HttpPost]
		[Route("login")]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if(!await _authManager.ValidateUser(userLoginDTO))
			{
				return Unauthorized();
			}

			var user = await _unitOfWork.UserRepo.Get(u => u.Email == userLoginDTO.Email);

			var userMapped = _mapper.Map<GetUserDTO>(user);

			return Accepted(new { Token = _authManager.CreateToken().Result, User = userMapped });
		}

	}
}
