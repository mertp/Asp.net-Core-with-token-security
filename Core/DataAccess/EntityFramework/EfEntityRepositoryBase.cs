using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Implementing the IEntityRepository
    //Using generic entity and context classes so code can be used again
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        //Where statements 
        where TEntity : class, IEntity, new()
        where TContext : DbContext,new()

    {
        //Implementing crud operations
        public void Add(TEntity Entity)
        {
            using (var context=new TContext())
            {
                var addedEntity = context.Entry(Entity);
                addedEntity.State = EntityState.Added;
                bool saveFailed;
                do
                {
                    //Exception Handling
                    saveFailed = false;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;


                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);


              
                
            }
        }

        public void Delete(TEntity Entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                bool saveFailed;
                do
                {
                    //Exception Handling
                    saveFailed = false;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;


                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

               
                
            }
        }

        public void DeleteById(int id, TEntity Entity)
        {
            using (var context = new TContext())
            {
                

                var deletedEntity = context.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                bool saveFailed;
                do
                {
                    //Exception Handling
                    saveFailed = false;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;


                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);



            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                    return filter == null ?
                    context.Set<TEntity>().ToList()
                   : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity Entity)
        {

            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                bool saveFailed;
                do
                {
                    //Exception Handling
                    saveFailed = false;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;


                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);



            }

        }
    }
}
