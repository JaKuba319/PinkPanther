using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
{
    public class TypeRepository : BaseRepository<Type>, ITypeRepository
    {
        protected override DbSet<Type> DbSet => _dbContext.Types;
        public TypeRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }


        public IEnumerable<Type> GetTypes()
        {
            return DbSet;
        }

        public override bool Update(Type entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.TypeName = entity.TypeName;
                return SaveChanges();
            }
            return false;
        }
    }
}
