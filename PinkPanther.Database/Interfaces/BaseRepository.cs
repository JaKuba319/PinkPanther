using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database.Interfaces
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected PinkPantherDbContex _dbContext;
        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(PinkPantherDbContex dbContex)
        {
            _dbContext = dbContex;
        }
        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }

        public bool Delete(int id)
        {
            var toDelete = DbSet.Where(entity => entity.Id == id).FirstOrDefault();
            if (toDelete != null)
            {
                DbSet.Remove(toDelete);
                return SaveChanges();
            }
            return false;
        }
        public bool Delete(Entity entity)
        {
            if (entity != null)
            {
                DbSet.Remove(entity);
                return SaveChanges();
            }
            return false;
        }

        public bool Update(Entity entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if(oldEntity != null)
            {
                oldEntity = entity;
                return SaveChanges();
            }
            return false;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
