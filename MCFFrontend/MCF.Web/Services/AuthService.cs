using MCF.Web.Models;
using MCF.Web.Services.IServices;
using MCF.Web.Utility;

namespace MCF.Web.Services
{
    public class AuthService: IAuthService
    {
        private readonly IBaseService baseService;

        public AuthService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ResponseDto?> Login(LoginRequestDto loginRequestDto)
        {
            return await this.baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.MCFAPIBase + "/api/auth/login"
            }, withBearer: false);
        }
    }
}
