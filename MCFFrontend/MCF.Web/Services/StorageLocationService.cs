using MCF.Web.Models;
using MCF.Web.Services.IServices;
using MCF.Web.Utility;

namespace MCF.Web.Services
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly IBaseService _baseService;
        public StorageLocationService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllStorageLocation()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MCFAPIBase + "/api/StorageLocation/GetAll"
            });
        }
    }
}
