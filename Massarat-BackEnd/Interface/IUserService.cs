using Massarat_BackEnd.DTO;
using Massarat_BackEnd.Service;

namespace Massarat_BackEnd.Services
{
	public interface IUserService
	{
		Task<UserResponse> RegiserUserAsync(RegisterDTO registerDTO);
		Task<UserResponse> LoginAsync(LoginDTO loginDTO);
	}
}
