using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Implementing the core layer
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
