namespace PinkPanther.Database
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
        public IEnumerable<Animal> GetAnimals();

        public bool AddAdoptedAnimal(Animal animal, Client client);
    }
}
