using Core.DataAccess;
using Core.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        //User data access layer with get claims method
        List<OperationClaim> GetClaims(User user);
    }
}
