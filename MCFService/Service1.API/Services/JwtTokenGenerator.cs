using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service1.API.Entities;
using Service1.API.Models;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service1.API.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOption jwtOption;

        public JwtTokenGenerator(IOptions<JwtOption> jwtOption)
        {
            this.jwtOption = jwtOption.Value;
        }
        public string GenerateToken(MsUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(this.jwtOption.Secret);

            var claimList = new List<Claim>();
            //{
            //    new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            //};
            claimList.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = this.jwtOption.Audience,
                Issuer = this.jwtOption.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
