using ECommerce.Common.Models;
using ECommerce.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Services.Services
{
    /// <summary>
    /// The Token Service
    /// </summary>
    public class TokenService
    {
        private readonly IConfiguration Config;
        private readonly IUserRepository UserRepository;

        public TokenService(IConfiguration config, IUserRepository userRepository)
        {
            Config = config;
            UserRepository = userRepository;
        }

        /// <summary>
        /// To Generate the token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public string GenerateJwtToken(string userId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Config["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, role),
            };

            // Create the token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),  
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  
        }

        /// <summary>
        /// To validate the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidUser(User user)
        {
            return user!=null && UserRepository.IsValidUser(user);
        }
    }

}
