using HuceDocs.Security.Common;
using HuceDocs.Security.Extension;
using HuceDocs.Security.SecurityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocsWebApi.JWT.Utility
{
    public class AuthozirationUtility : IAuthozirationUtility
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthozirationUtility> _logger;

        public AuthozirationUtility(
            IConfiguration configuration,
            ILogger<AuthozirationUtility> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string RenderAccessToken(current_user_access access_user)
        {
            var audience = _configuration["TokenAuthenticationLsiteUrl"];

            var jwtToken = new JwtSecurityToken(
                issuer: audience,
                audience: audience,
                claims: GetTokenClaims(access_user),
                expires: access_user.ExpireTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constant.SecretSercurityKey)), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public JwtSecurityToken GetRequestAccessToken(HttpContext context)
        {
            try
            {
                var token = GetToken(context);
                token = token.Replace("Bearer", "");
                return new JwtSecurityTokenHandler().ReadJwtToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message: " Read JwtToken fail");
                return null;
                
            }
        }
        private string GetToken(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].ToString();
            return string.IsNullOrWhiteSpace(token) ? string.Empty : token;
        }

        private IEnumerable<Claim> GetTokenClaims(current_user_access access_user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, access_user.Email),
                new Claim(JwtRegisteredClaimNames.Typ, string.Join(",", access_user.Roles)),
                new Claim(JwtRegisteredClaimNames.NameId, access_user.UserName),
                new Claim(JwtRegisteredClaimNames.Exp, access_user.ExpireTime.ToShortDateString()),
                new Claim(JwtRegisteredClaimNames.Sub, access_user.UserId.ToString())
            };
        }
        public string GetClaim(HttpContext context, string claimType)
        {
            var jwtSecurityToken = GetRequestAccessToken(context);
            return jwtSecurityToken?.GetClaimValue(claimType.ToString());
        }

        public List<Claim> GetClaims(HttpContext context)
        {
            var jwtSecurityToken = GetRequestAccessToken(context);
            return jwtSecurityToken?.Payload.Claims.ToList();
        }

        public async Task<int> GetUserIdAsync(HttpContext context)
        {
            var jwtSecurityToken = GetRequestAccessToken(context);
            var userIdClaim = jwtSecurityToken?.GetClaimValue(JwtRegisteredClaimNames.Sub.ToString());
            double userExp;
            if (!double.TryParse(jwtSecurityToken?.GetClaimValue(JwtRegisteredClaimNames.Exp.ToString()), out userExp))
            {
                return 0;
            }
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (userExp < now) { return -1; } // expired
            int userId = 0;
            if (userIdClaim != null && int.TryParse(userIdClaim, out userId))
            {
                return userId;
            }
            return -1;
        }

        public int GetUserId(HttpContext context)
        {
            var jwtSecurityToken = GetRequestAccessToken(context);
            var userIdClaim = jwtSecurityToken?.GetClaimValue(JwtRegisteredClaimNames.Sub.ToString());
            double userExp;
            if (!double.TryParse(jwtSecurityToken?.GetClaimValue(JwtRegisteredClaimNames.Exp.ToString()), out userExp))
            {
                return 0;
            }
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (userExp < now) { return -1; } // expired
            int userId = 0;
            if (userIdClaim != null && int.TryParse(userIdClaim, out userId))
            {
                return userId;
            }
            return -1;
        }
    }
}
