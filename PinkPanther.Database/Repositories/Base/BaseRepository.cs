using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
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

        public abstract bool Update(Entity entity);

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
