namespace PinkPanther.Database
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
        public IEnumerable<Animal> GetAnimals();
    }
}
