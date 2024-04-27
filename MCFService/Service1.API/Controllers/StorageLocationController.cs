using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;

namespace Service1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StorageLocationController : ControllerBase
    {
        private readonly IStorageLocationService _storageLocationService;
        private readonly ResponseDto _responseDto;

        public StorageLocationController(IStorageLocationService storageLocationService)
        {
            _storageLocationService = storageLocationService;
            _responseDto = new();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _responseDto.Result = await _storageLocationService.GetAll();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message.ToString();
            }
            return Ok(_responseDto);
        }

    }
}
