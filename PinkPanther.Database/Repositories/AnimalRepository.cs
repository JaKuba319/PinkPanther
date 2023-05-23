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
    }
}
