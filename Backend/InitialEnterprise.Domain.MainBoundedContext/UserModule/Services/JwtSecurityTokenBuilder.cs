using InitialEnterprise.Domain.MainBoundedContext.Api;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using InitialEnterprise.Infrastructure.Api.Auth;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

public class JwtSecurityTokenBuilder : IJwtSecurityTokenBuilder
{
    private readonly IOptions<JwtAuthentication> jwtAuthentication;

    public JwtSecurityTokenBuilder(IOptions<JwtAuthentication> jwtAuthentication)
    {
        this.jwtAuthentication = jwtAuthentication;
    }

    private static IEnumerable<Claim> MergeUserClaimsWithDefaultClaims(ApplicationUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.TimeOfDay.Ticks.ToString(),
                    ClaimValueTypes.Integer64)
            };

        return claims;
    }

    public string CreateToken(ApplicationUser user)
    {
        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthentication.Value.SecurityKey));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(nameof(ApplicationUser.Id), user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
            Issuer = jwtAuthentication.Value.ValidIssuer,
            Audience = jwtAuthentication.Value.ValidAudience
        };

        if (user.Claims.IsNotNullOrEmpty())
        {
            tokenDescriptor.Subject.AddClaims(user.Claims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)));
        }
        if (user.UserRoles.IsNotNullOrEmpty())
        {
            tokenDescriptor.Subject.AddClaims(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));
        }

        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}