namespace PinkPanther.Core
{
    public interface IManager
    {
        public AnimalDto GetAnimalById(int id);
        public IEnumerable<AnimalDto> GetAnimals(string filterstring, string type, bool adoptedOnly = false, bool vaccinatedOnly = false);
        public ClientDto GetClientById(int id);
        public IEnumerable<ClientDto> GetClients(string filterstring, bool gender);
        public IEnumerable<ClientDto> GetClients(string filterstring);
        public TypeDto GetTypeById(int id);
        public IEnumerable<TypeDto> GetTypes();
        public RaceDto GetRaceById(int id);
        public IEnumerable<RaceDto> GetRaces();
        public bool DeleteAnimal(int id);
        public bool DeleteClient(int id);
        public bool DeleteType(int id);
        public bool DeleteRace(int id);
        public bool UpdateAnimal(AnimalDto animal);
        public bool UpdateClient(ClientDto client);
        public bool UpdateType(TypeDto type);
        public bool UpdateRace(RaceDto race);
    }
}
