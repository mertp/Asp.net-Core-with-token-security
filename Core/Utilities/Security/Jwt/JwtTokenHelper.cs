using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtTokenHelper : ITokenHelper
    {
        public IConfiguration configuration { get; }
        private TokenOptions _tokenOptions;
        public JwtTokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securitykey = SecurityKeyHelper.SecurityKeyCreator(_tokenOptions.SecurityKey);
            var signingcreadential = SigningCreadentialHelper.CreateSigningCredentials(securitykey);
        }
    }
}
