using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using HuceDocs.Security.SecurityModel;
using Microsoft.AspNetCore.Http;

namespace HuceDocsWebApi.JWT.Utility
{
    public interface IAuthozirationUtility
    {
        string RenderAccessToken(current_user_access access_user);
        JwtSecurityToken GetRequestAccessToken(HttpContext context);
        Task<int> GetUserIdAsync(HttpContext httpContext);
        string GetClaim(HttpContext context, string claimType);
        List<Claim> GetClaims(HttpContext context);
        int GetUserId(HttpContext context);
    }
}
