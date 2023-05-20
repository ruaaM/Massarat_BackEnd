using Massarat_BackEnd.DTO;
using Massarat_BackEnd.Services;
using Microsoft.AspNetCore.Identity;

namespace Massarat_BackEnd.Service
{
	public class UserService : IUserService
	{
		private readonly UserManager<IdentityUser> _userManager;

		public UserService(UserManager<IdentityUser> userManager)
        {
		  _userManager = userManager;
		}

		public Task<UserResponse> LoginAsync(LoginDTO loginDTO)
		{
			throw new NotImplementedException();
		}

		public async Task<UserResponse> RegiserUserAsync(RegisterDTO registerDTO)
		{
			if(registerDTO == null)
		    throw new NullReferenceException("Register Dto is null");

			if(registerDTO.Password != registerDTO.ConfirmPassword)
			{
				return new UserResponse
				{
					Message = "Passwords doesnt match",
					isSuccess = false,
				};
			}
			var user = new IdentityUser
			{
				PhoneNumber = registerDTO.mobileNumber,
			UserName = registerDTO.mobileNumber,
			};

			var result = await _userManager.CreateAsync(user, registerDTO.Password);

			if (result.Succeeded)
			{
				return new UserResponse
				{
					Message = "user created successfully",
					isSuccess = true,
				};
			}
			return new UserResponse
			{
				Message = "user didn't create",
				isSuccess = false,
				Errors = result.Errors.Select(e => e.Description)
			};
			}
		}
	}
