using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service1.API.Models.Dtos;
using Service1.API.Services;
using Service1.API.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Service1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BpkbController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly IBpkbService _bpkbService;

        public BpkbController(IBpkbService bpkbService)
        {
            _responseDto = new();
            _bpkbService = bpkbService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll() {
            try
            {
                _responseDto.Result = await _bpkbService.GetAll();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message.ToString();
            }
            return Ok(_responseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                _responseDto.Result = await _bpkbService.GetById(id);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message.ToString();
            }
            return Ok(_responseDto);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TrBpkbDto trBpkbDto) {
            try
            {
                var username = User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
                trBpkbDto.CreatedBy = username;
                trBpkbDto.LastUpdatedBy = username;
                var result = await _bpkbService.Create(trBpkbDto);
                _responseDto.Result = result;
                return Ok(_responseDto);
            }
            catch (Exception e)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = e.Message;
                return BadRequest(_responseDto);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] TrBpkbDto trBpkbDto)
        {
            try
            {
                var username = User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
                trBpkbDto.LastUpdatedBy = username;
                var result = await _bpkbService.Update(trBpkbDto);
                _responseDto.Result = result;
                return Ok(_responseDto);
            }
            catch (Exception e)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = e.Message;
                return BadRequest(_responseDto);
            }
        }



    }
}
