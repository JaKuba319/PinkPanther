using PinkPanther.Database;

namespace PinkPanther.Core
{
    public class Manager : IManager
    {
        IAnimalRepository _animalRepository;
        IClientRepository _clientRepository;
        ITypeRepository _typeRepository;
        IRaceRepository _raceRepository;
        DtoMapper _mapper;

        public Manager(IAnimalRepository animalRepository, IClientRepository clientRepository, ITypeRepository typeRepository, IRaceRepository raceRepository, DtoMapper mapper)
        {
            _animalRepository = animalRepository;
            _clientRepository = clientRepository;
            _typeRepository = typeRepository;
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        #region AddRegion

        public bool AddAdoption(AnimalDto animal, ClientDto client)
        {
            var animalEntity = _mapper.Map(animal);
            var clientEntity = _mapper.Map(client);

            var animalCheck = _animalRepository.GetAnimals().Where(entity => entity.Id == animalEntity.Id).FirstOrDefault();
            var clientCheck = _clientRepository.GetClients().Where(entity => entity.Id == clientEntity.Id).FirstOrDefault();

            if(animalCheck == null || clientCheck == null) return false;

            return _animalRepository.AddAdoptedAnimal(animalEntity, clientEntity);
        }

        public bool AddAnimal(AnimalDto animal)
        {
            var entity = _mapper.Map(animal);

            entity.Client = null;
            entity.Race = null;

            return _animalRepository.AddNew(entity);
        }

        public bool AddClient(ClientDto client)
        {
            var entity = _mapper.Map(client);
            entity.Animals = _mapper.Map(client.Animals);
            return _clientRepository.AddNew(entity);
        }

        public bool AddRace(RaceDto race)
        {
            var entity = _mapper.Map(race);

            entity.Type = null;

            return _raceRepository.AddNew(entity);
        }

        public bool AddType(TypeDto type)
        {
            return _typeRepository.AddNew(_mapper.Map(type));
        }
        #endregion

        #region GetRegion

        public AnimalDto GetAnimalById(int id)
        {
            var animal = _animalRepository.GetAnimals().Where(animal => animal.Id == id).FirstOrDefault();
            if (animal == null) return null;
            return _mapper.Map(animal);
        }

        public IEnumerable<AnimalDto> GetAnimals(string filterstring, string type, bool adoptedOnly = false, bool vaccinatedOnly = false)
        {
            var animals = _animalRepository.GetAnimals();

            if (animals == null) return null;

            if (!string.IsNullOrEmpty(type))
            {
                animals = animals.Where(animal =>
                        animal.Race.Type.TypeName == type).ToList();
            }

            animals = animals.Where(animal =>
                    {
                        bool isAdopted = animal.Client != null;
                        return isAdopted == adoptedOnly || !adoptedOnly;
                    })
                    .Where(animal =>
                    {
                        return animal.IsVaccinated == vaccinatedOnly || !vaccinatedOnly;
                    }).ToList();

            if (!string.IsNullOrEmpty(filterstring))
            {
                animals = animals.Where(animal =>
                    {
                        return animal.Name.ToLower().Contains(filterstring.ToLower());
                    })
                    .ToList();

                return _mapper.Map(animals.ToList());
            }

            return _mapper.Map(animals.ToList());
        }

        public ClientDto GetClientById(int id)
        {
            var client = _clientRepository.GetClients().Where(client => client.Id == id).FirstOrDefault();
            if (client == null) return null;
            return _mapper.Map(client);
        }

        public IEnumerable<ClientDto> GetClients(string filterstring, bool gender)
        {
            var clients = _clientRepository.GetClients().Where(client =>
            {
                return client.Gender == gender;
            }).ToList();

            if(!string.IsNullOrEmpty(filterstring))
            {
                clients = clients.Where(client =>
                    client.FirstName.ToLower().Contains(filterstring) ||
                        client.LastName.ToLower().Contains(filterstring)).ToList();
            }
            return _mapper.Map(clients);
        }

        public IEnumerable<ClientDto> GetClients(string filterstring)
        {
            var clients = _clientRepository.GetClients().ToList();

            if (!string.IsNullOrEmpty(filterstring))
            {
                clients = clients.Where(client =>
                    client.FirstName.ToLower().Contains(filterstring) ||
                        client.LastName.ToLower().Contains(filterstring)).ToList();
            }
            return _mapper.Map(clients);
        }

        public TypeDto GetTypeById(int id)
        {
            var type = _typeRepository.GetTypes().Where(type => type.Id == id).FirstOrDefault();
            if (type == null) return null;
            return _mapper.Map(type);
        }

        public IEnumerable<TypeDto> GetTypes()
        {
            return _mapper.Map(_typeRepository.GetTypes().ToList());
        }

        public RaceDto GetRaceById(int id)
        {
            var race = _raceRepository.GetRaces().Where(race => race.Id == id).FirstOrDefault();
            if (race == null) return null;
            return _mapper.Map(race);
        }

        public IEnumerable<RaceDto> GetRaces()
        {
            return _mapper.Map(_raceRepository.GetRaces().ToList());
        }

        #endregion

        #region DeleteRegion
        public bool DeleteAnimal(int id)
        {
            return _animalRepository.Delete(id);
        }

        public bool DeleteClient(int id)
        {
            return _clientRepository.Delete(id);
        }

        public bool DeleteType(int id)
        {
            return _typeRepository.Delete(id);
        }

        public bool DeleteRace(int id)
        {
            return _raceRepository.Delete(id);
        }

        #endregion

        #region UpdateRegion

        public bool UpdateAnimal(AnimalDto animal)
        {
            return _animalRepository.Update(_mapper.Map(animal));
        }

        public bool UpdateClient(ClientDto client)
        {
            return _clientRepository.Update(_mapper.Map(client));
        }
        public bool UpdateType(TypeDto type)
        {
            return _typeRepository.Update(_mapper.Map(type));
        }
        public bool UpdateRace(RaceDto race)
        {
            return _raceRepository.Update(_mapper.Map(race));
        }
        #endregion

    }
}
