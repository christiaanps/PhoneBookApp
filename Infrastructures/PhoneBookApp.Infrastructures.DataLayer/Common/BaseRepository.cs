using PhoneBookApp.Domain.Contracts.Common;
using PhoneBookApp.Domain.Core;
using PhoneBookApp.Infrastructures.DataLayer.Common;
using System.Linq;

namespace PhoneBookApp.Infrastructures.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity :BaseEntity,new()
    {
        private readonly PhoneBookAppContext dbContext;

        public BaseRepository(PhoneBookAppContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                Id = id
            };
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
