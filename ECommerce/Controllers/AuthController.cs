using ECommerce.Common.Models;
using ECommerce.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService TokenService;
        private readonly IDistributedCache DistributedCache;

        /// <summary>
        /// The AuthController constructor
        /// </summary>
        /// <param name="token"></param>
        /// <param name="distributedCache"></param>
        public AuthController(TokenService token,IDistributedCache distributedCache)
        {
            TokenService = token;
            DistributedCache = distributedCache;
        }

        /// <summary>
        /// To authenticate the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(User user)
        {
            var tokenCacheKey = $"Token_{user.Username}";
            var cachedToken = DistributedCache.GetString(tokenCacheKey);

            if (string.IsNullOrEmpty(cachedToken) && TokenService.IsValidUser(user))
            {
                var token = TokenService.GenerateJwtToken(user.Password, user.Role);
                DistributedCache.SetString(tokenCacheKey, token, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) 
                });
                return Ok(new { token });
            }

            return Ok(new { token = cachedToken });
        }
    }
}
