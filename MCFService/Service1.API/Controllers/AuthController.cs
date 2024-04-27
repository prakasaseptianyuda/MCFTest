using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;

namespace Service1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _auth;
        private readonly IConfiguration _configuration;
        private readonly ResponseDto _responseDto;

        public AuthController(IAuthService auth, IConfiguration configuration)
        {
            _auth = auth;
            _configuration = configuration;
            _responseDto = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _auth.Login(model);
            if (loginResponse.User == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Username or Password is Incorrect";
            }
            _responseDto.Result = loginResponse;
            return Ok(_responseDto);
        }
    }
}
