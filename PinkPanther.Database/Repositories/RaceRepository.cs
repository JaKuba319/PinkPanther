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
            return DbSet;
        }

        public override bool Update(Race entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.RaceName = entity.RaceName;
                return SaveChanges();
            }
            return false;
        }
    }
}
