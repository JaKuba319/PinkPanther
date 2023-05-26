using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        protected override DbSet<Animal> DbSet => _dbContext.Animals;

        public AnimalRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return DbSet.Include(animal => animal.Type).Include(animal => animal.Race).Include(animal => animal.Client);
        }

        public override bool Update(Animal entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.Name = entity.Name;
                oldEntity.Description = entity.Description;
                oldEntity.TypeId = entity.TypeId;
                oldEntity.RaceId = entity.RaceId;
                oldEntity.IsVaccinated = entity.IsVaccinated;
                oldEntity.Gender = entity.Gender;
                oldEntity.BirthDate = entity.BirthDate;
                return SaveChanges();
            }
            return false;
        }
    }
}
