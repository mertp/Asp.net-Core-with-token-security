using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Creating a generic interface for crud operations in data access layer.
    //where statement: the generic entity should be a class, it should be inherited from IEntity and it should be neweable.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);

        IList<T> GetList(Expression<Func<T, bool>> filter=null);

        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

        void DeleteById(int id, T Entity);
        
    }
}
