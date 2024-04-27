using Microsoft.AspNetCore.Identity;
using Service1.API.Entities;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;

namespace Service1.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.MsUser.FirstOrDefault(w => w.UserName == loginRequestDto.UserName && w.Password == loginRequestDto.Password && w.IsActive == true);

            if (user == null)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            UserDto userDto = new UserDto()
            {
                Username = user.UserName,
                Id = user.UserId,
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = _jwtTokenGenerator.GenerateToken(user)
            };

            return loginResponseDto;
        }
    }
}
