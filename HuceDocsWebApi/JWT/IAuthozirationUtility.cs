using HuceDocsDemo.Security.SecurityModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HuceDocsDemo.JWT.Utility
{
    public interface IAuthozirationUtility
    {
        string RenderAccessToken(current_user_access access_user);
        JwtSecurityToken GetRequestAccessToken(HttpContext context);

        string GetUserId(HttpContext httpContext);
        string GetClaim(HttpContext context, string claimType);
        List<Claim> GetClaims(HttpContext context);
    }
}
