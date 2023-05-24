using AutoMapper;
using PinkPanther.Database;

namespace PinkPanther.Core
{
    public class DtoMapper
    {
        IMapper _mapper;

        public DtoMapper()
        {
            _mapper = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Client, ClientDto>().ReverseMap();
                opt.CreateMap<Animal, AnimalDto>().ReverseMap();
                opt.CreateMap<Database.Type, TypeDto>().ReverseMap();
                opt.CreateMap<Race, RaceDto>().ReverseMap();
            }).CreateMapper();  
        }

        #region ClientMap
        public Client Map(ClientDto clientDto)
            => _mapper.Map<Client>(clientDto);

        public List<Client> Map(List<ClientDto> clientDtos)
            => _mapper.Map<List<Client>>(clientDtos);

        public ClientDto Map(Client client)
            => _mapper.Map<ClientDto>(client);

        public List<ClientDto> Map(List<Client> clients)
            => _mapper.Map<List<ClientDto>>(clients);

        #endregion

        #region AnimalMap
        public Animal Map(AnimalDto animalDto)
            => _mapper.Map<Animal>(animalDto);

        public List<Animal> Map(List<AnimalDto> animalDtos)
            => _mapper.Map<List<Animal>>(animalDtos);

        public AnimalDto Map(Animal animal)
            => _mapper.Map<AnimalDto>(animal);

        public List<AnimalDto> Map(List<Animal> animals)
            => _mapper.Map<List<AnimalDto>>(animals);

        #endregion

        #region TypeMap

        public Database.Type Map(TypeDto typeDto)
            => _mapper.Map<Database.Type>(typeDto);

        public List<Database.Type> Map(List<TypeDto> typeDtos)
            => _mapper.Map<List<Database.Type>>(typeDtos);

        public TypeDto Map(Database.Type type)
            => _mapper.Map<TypeDto>(type);

        public List<TypeDto> Map(List<Database.Type> types)
            => _mapper.Map<List<TypeDto>>(types);

        #endregion

        #region RaceMap
        public Race Map(RaceDto raceDto)
            => _mapper.Map<Race>(raceDto);

        public List<Race> Map(List<RaceDto> raceDtos)
            => _mapper.Map<List<Race>>(raceDtos);

        public RaceDto Map(Race race)
            => _mapper.Map<RaceDto>(race);

        public List<RaceDto> Map(List<Race> races)
            => _mapper.Map<List<RaceDto>>(races);
        #endregion
    }
}
