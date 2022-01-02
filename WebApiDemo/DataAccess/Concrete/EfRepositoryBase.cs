using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiDemo.DataAccess.Abstract;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess.Concrete
{
    public class EfRepositoryBase<TEntity, TContext> : IEfRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TContext context=new TContext())
            {
                var ID = context.Set<TEntity>().Find(id);
                context.Entry(ID).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> Filter)
        {
            using (TContext context=new TContext())
            {
               return context.Set<TEntity>().SingleOrDefault(Filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (TContext context=new TContext())
            {
                return Filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(Filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
