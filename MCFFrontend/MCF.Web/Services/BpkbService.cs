using MCF.Web.Models;
using MCF.Web.Services.IServices;
using MCF.Web.Utility;

namespace MCF.Web.Services
{
    public class BpkbService : IBpkbService
    {
        private readonly IBaseService _baseService;

        public BpkbService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> Create(TrBpkbDto trBpkbDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = trBpkbDto,
                Url = SD.MCFAPIBase + "/api/Bpkb/Create/"
            });
        }

        public async Task<ResponseDto?> Update(TrBpkbDto trBpkbDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = trBpkbDto,
                Url = SD.MCFAPIBase + "/api/Bpkb/Update/"
            });
        }

        public async Task<ResponseDto?> GetAllTrBpkb()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.MCFAPIBase + "/api/Bpkb/"
            });
        }

        public async Task<ResponseDto?> GetTrBpkbById(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.MCFAPIBase + "/api/Bpkb/" + id
            });
        }
    }
}
