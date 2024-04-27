using Service1.API.Entities;
using Service1.API.Models.Dtos;

namespace Service1.API.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(MsUser userDto);
    }
}
