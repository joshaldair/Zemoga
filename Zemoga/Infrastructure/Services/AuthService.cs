using Application.Constants;
using Application.Contracts.Identity;
using Application.Models;
using Infrastructure.Models;
using Infrastructure.Persistance;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        protected readonly ZemogaContext _context;
        private readonly JWTSettings _jwtSettings;

        public AuthService(ZemogaContext context, IOptions<JWTSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = _context.Users.Where(x => x.UserName == authRequest.UserName && x.Password == encriptar(authRequest.Password) && x.IsActive == true).FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"User or Password are incorrect");
            }

            var appUser = new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                ProfileId = user.ProfileId,
            };

            var token = await GenerarToken(appUser);

            var authResponse = new AuthResponse
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ProfileId = user.ProfileId.ToString()

            };

            return authResponse;
        }

        private async Task<JwtSecurityToken> GenerarToken(ApplicationUser applicationUser)
        {

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
                new Claim(ClaimTypes.Name ,applicationUser.UserName),
                new Claim(ClaimTypes.Role , "admin"),
                new Claim(CustomClaimTypes.Uid , applicationUser.Id.ToString())
            };

            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signCredentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: signCredentials
                );

            return jwtSecurityToken;
        }

        public string encriptar(string Cadena)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] vectoBytes = System.Text.Encoding.UTF8.GetBytes(Cadena);
            byte[] inArray = SHA1.ComputeHash(vectoBytes);
            SHA1.Clear();
            return Convert.ToBase64String(inArray);
        }
    }
}
