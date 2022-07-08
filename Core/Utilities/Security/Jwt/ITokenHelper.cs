using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Core.Utilities.Security.Jwt
{
    //Token helper interface
    public interface ITokenHelper
    {
      
       
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
