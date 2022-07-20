    using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthWindContext>, IUserDal
    {
        //Implementation of  GetClaims method
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthWindContext())
            {
                //Join Operation for user operation claims
                var result = from operationClaims in context.OperationClaim
                             join UserOperationsClaim in context.UserOperationClaim
                             on operationClaims.Id equals UserOperationsClaim.OperationClaimId
                             where UserOperationsClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name };
                return result.ToList();
            }
        }
    }
}