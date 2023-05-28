using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        protected override DbSet<Race> DbSet => _dbContext.Races;
        public RaceRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }


        public IEnumerable<Race> GetRaces()
        {
            return DbSet.Include(race => race.Type);
        }

        public override bool Update(Race entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.RaceName = entity.RaceName;
                oldEntity.TypeId = entity.TypeId;
                return SaveChanges();
            }
            return false;
        }
    }
}
