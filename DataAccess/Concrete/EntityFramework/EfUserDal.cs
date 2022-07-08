    using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
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
                var result = from operationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperations
                             on operationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
        }
    }
}
