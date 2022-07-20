using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtTokenHelper : ITokenHelper
    {
        public IConfiguration configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtTokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            //Getting token options section info from appsettings.json with getSection function
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Creating token
            var securitykey = SecurityKeyHelper.SecurityKeyCreator(_tokenOptions.SecurityKey);
            var signingcreadential = SigningCreadentialHelper.CreateSigningCredentials(securitykey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingcreadential, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token=jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }
        //Creating the jwt security token
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials

                ) ;
            return jwt ;
        }
        //Setting up the claims with claim class extensions
        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName(user.FirstName);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            
            return claims;
        }
    }
}
