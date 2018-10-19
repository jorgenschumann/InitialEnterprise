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

public class JwtSecurityTokenBuilder : IJwtSecurityTokenBuilder
{
    readonly IOptions<JwtAuthentication> jwtAuthentication;

    public JwtSecurityTokenBuilder(IOptions<JwtAuthentication> jwtAuthentication)
    {
        this.jwtAuthentication = jwtAuthentication;
    }

    //public string CreateToken(ApplicationUser user)
    //{
    //    var authenicationClaims = BuildAuthenicationClaims(user);
    //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenicationClaims, "Token");
    //    //claimsIdentity.AddClaims(....));

    //    var payLoad = new JwtPayload(jwtAuthentication.Value.ValidIssuer,
    //        jwtAuthentication.Value.ValidAudience,
    //        claimsIdentity.Claims, null,
    //        DateTime.UtcNow.AddMinutes(1));

    //    var symmetricSecurityKey = jwtAuthentication.Value.SymmetricSecurityKey;
    //    var signingCredentials = jwtAuthentication.Value.SigningCredentials;
    //    var header = new JwtHeader(signingCredentials);
    //    var jwtSecurityToken = new JwtSecurityToken(header, payLoad);

    //    return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

    //}

    //private Claim[] BuildAuthenicationClaims(ApplicationUser user)
    //{
    //    var claims = new[] {
    //            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //            new Claim(JwtRegisteredClaimNames.Email, user.Email),
    //            new Claim(nameof(ApplicationUser.Id), user.Id.ToString()),
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //        };

    //    return claims;
    //}




    //public string CreateToken(ApplicationUser user)
    //{
    //    var token = new JwtSecurityToken(
    //       issuer: jwtAuthentication.Value.ValidIssuer,
    //       audience: jwtAuthentication.Value.ValidAudience,
    //       claims: new[]
    //       {
    //                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //           // more claims 
    //       },
    //       expires: DateTime.UtcNow.AddDays(1),
    //       notBefore: DateTime.UtcNow,
    //       signingCredentials: jwtAuthentication.Value.SigningCredentials);

    //    return string.Format("{0}", new JwtSecurityTokenHandler().WriteToken(token));
    //}

    //namespace InitialEnterprise.Infrastructure.Api.Auth
    //{




    //    public class JwtSecurityTokenBuilder : IJwtSecurityTokenBuilder
    //    {


    //        public JwtSecurityTokenBuilder(IOptions<JwtAuthentication> jwtAuthentication)
    //        {

    //        }

    //        //public string CreateToken(ApplicationUser user, string secret)
    //        //{

    //        //        var claims = new[] {
    //        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),  
    //        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //        //};

    //        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    //        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        //    var token = new JwtSecurityToken("http://localhost:63928/",
    //        //      "http://localhost:63928/",
    //        //      claims,
    //        //      expires: DateTime.Now.AddMinutes(30),
    //        //      signingCredentials: creds);

    //        //    return " bearer " +  new JwtSecurityTokenHandler().WriteToken(token);
    //        //}

    //    //            "JwtAuthentication": {
    //    //  "SecurityKey": "ouNtF8Xds1jE55/d+iVZ99u0f2U6lQ+AHdiPFwjVW3o=",
    //    //  "ValidAudience": "https://localhost:63928/",
    //    //  "ValidIssuer": "https://localhost:63928/"
    //    //}


    private static IEnumerable<Claim> MergeUserClaimsWithDefaultClaims(ApplicationUser user)
    {
        var claims = new List<Claim>()
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


        var jwt = new JwtSecurityToken(issuer: jwtAuthentication.Value.ValidIssuer,
                                       audience: jwtAuthentication.Value.ValidAudience,
                                       claims: MergeUserClaimsWithDefaultClaims(user),
                                       notBefore: DateTime.UtcNow,
                                       expires: DateTime.UtcNow.AddDays(1),
                                       signingCredentials: jwtAuthentication.Value.SigningCredentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return accessToken;

        //var tokenHandler = new JwtSecurityTokenHandler();
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(nameof(ApplicationUser.Id), user.Id.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString())
        //    }),
        //    Expires = DateTime.UtcNow.AddDays(1),
        //    SigningCredentials = jwtAuthentication.Value.SigningCredentials,
        //    Issuer = jwtAuthentication.Value.ValidIssuer,
        //    Audience = jwtAuthentication.Value.ValidAudience
        //};

        //if (user.Claims.IsNotNullOrEmpty())
        //{
        //    tokenDescriptor.Subject.AddClaims(user.Claims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)));
        //}
        //if (user.UserRoles.IsNotNullOrEmpty())
        //{
        //    tokenDescriptor.Subject.AddClaims(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));
        //}

        //var token = tokenHandler.CreateToken(tokenDescriptor);

        //return tokenHandler.WriteToken(token);
    }
}

//        //public string CreateToken(ApplicationUser user, string secret)
//        //{
//        //    var claims = new List<Claim>
//        //    {
//        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//        //        new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString())
//        //    };

//        //    if (user.Claims.IsNotNullOrEmpty())
//        //    {
//        //        foreach (var claim in user.Claims)
//        //        {
//        //            claims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
//        //        }               
//        //    }        


//        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
//        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//        //    var expires = DateTime.UtcNow.AddDays(7);

//        //    var token = new JwtSecurityToken(
//        //        "http://localhost:63928/",
//        //        "http://localhost:63928/",
//        //        claims,
//        //        expires: expires,
//        //        signingCredentials: creds
//        //    );

//        //    return new JwtSecurityTokenHandler().WriteToken(token);
//        //}

//        //public string CreateToken(ApplicationUser user, string secret)
//        //{
//        //    var tokenHandler = new JwtSecurityTokenHandler();
//        //    var key = Encoding.ASCII.GetBytes(secret);

//        //    var tokenDescriptor = new SecurityTokenDescriptor
//        //    {
//        //        Subject = new ClaimsIdentity(new Claim[]
//        //        {
//        //            new Claim(ClaimTypes.Sid,user.Id.ToString()),
//        //            new Claim(ClaimTypes.Name,user.UserName),
//        //            new Claim(ClaimTypes.Email,user.Email)
//        //        }),
//        //        Expires = DateTime.UtcNow.AddDays(7),

//        //        SigningCredentials = new SigningCredentials(
//        //            new SymmetricSecurityKey(key),
//        //            SecurityAlgorithms.HmacSha256Signature)
//        //    };

//        //    if (user.Claims.IsNotNullOrEmpty())
//        //    {
//        //        tokenDescriptor.Subject.AddClaims(user.Claims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)));
//        //    }
//        //    if (user.UserRoles.IsNotNullOrEmpty())
//        //    {
//        //        tokenDescriptor.Subject.AddClaims(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));
//        //    }

//        //    var token = tokenHandler.CreateToken(tokenDescriptor);
//        //    var tokenString = tokenHandler.WriteToken(token);

//        //    return tokenString;
//        //}
//    }
//}
