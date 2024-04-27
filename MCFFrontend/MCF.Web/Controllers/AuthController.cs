using MCF.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using MCF.Web.Services.IServices;

namespace MCF.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		private readonly ITokenProvider _tokenProvider;

		public AuthController(IAuthService authService, ITokenProvider tokenProvider)
		{
			_authService = authService;
			_tokenProvider = tokenProvider;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDto loginRequestDto = new();
			return View(loginRequestDto);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginRequestDto obj)
		{
			ResponseDto? responseDto = await _authService.Login(obj);

			if (responseDto != null && responseDto.IsSuccess)
			{
				LoginResponseDto? loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
				await SignInUser(loginResponseDto);
				_tokenProvider.SetToken(loginResponseDto.Token);
				return RedirectToAction("Index", "TrBpkb");
			}
			else
			{
				TempData["error"] = responseDto.Message;
				return View(obj);
			}
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "TrBpkb");
        }

        private async Task SignInUser(LoginResponseDto model)
		{
			var handler = new JwtSecurityTokenHandler();

			var jwt = handler.ReadJwtToken(model.Token);

			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
			identity.AddClaim(new Claim(ClaimTypes.Name,
				jwt.Claims.FirstOrDefault(w => w.Type == JwtRegisteredClaimNames.Name).Value));

			var principal = new ClaimsPrincipal(identity);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

		}

	}
}
