using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data;
using TransportSystem.Models;

namespace TransportSystem.Services
{
	public interface IAuthManager
	{
		Task<bool> ValidateUser(UserLoginDTO userDTO);
		Task<string> CreateToken();
	}
}
