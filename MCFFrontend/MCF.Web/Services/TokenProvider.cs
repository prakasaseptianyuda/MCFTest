using MCF.Web.Services.IServices;
using MCF.Web.Utility;

namespace MCF.Web.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public void ClearToken()
        {
            this.contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = this.contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);
            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            this.contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }

    }
}
