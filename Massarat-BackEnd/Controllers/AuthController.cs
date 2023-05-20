using Massarat_BackEnd.DTO;
using Massarat_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace Massarat_BackEnd.Controllers
{
	public class AuthController : Controller
	{
		private readonly IUserService _userService;

		public AuthController(IUserService userService)
        {
			_userService = userService;
		}
		//[HttpPost]
		//      public async Task<IActionResult> RegisterAsync(RegisterDTO registerDTO)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var result =await _userService.RegiserUserAsync(registerDTO);
		//		if (result.isSuccess)
		//		{
		//			return Ok(result);
		//		}
		//		return BadRequest(result);

		//	}
		//	return BadRequest("Something went wrong");

		//}



		[HttpPost]
		[Route("auth/[Controller]/[Action]")]
		public async Task<IActionResult> RegisterAsync(RegisterDTO registerDTO)
		{

				var result = await _userService.RegiserUserAsync(registerDTO);

				if (result.isSuccess)
				{
					return Ok(result);
				}

			
			return BadRequest(result.Errors);
		}


		
	}
}
