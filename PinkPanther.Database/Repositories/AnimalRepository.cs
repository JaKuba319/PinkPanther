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
            return DbSet.Include(animal => animal.Race).ThenInclude(race => race.Type).Include(animal => animal.Client);
        }

        public override bool Update(Animal entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.Name = entity.Name;
                oldEntity.Description = entity.Description;
                oldEntity.RaceId = entity.RaceId;
                oldEntity.IsVaccinated = entity.IsVaccinated;
                oldEntity.Gender = entity.Gender;
                oldEntity.BirthDate = entity.BirthDate;
                return SaveChanges();
            }
            return false;
        }

        public bool AddAdoptedAnimal(Animal animal, Client client)
        {
            var entity = DbSet.Where(entity => entity.Id == animal.Id).FirstOrDefault();

            if (entity == null) return false;

            entity.ClientId = client.Id;

            return SaveChanges();
        }
    }
}
