using AutoMapper;
using PinkPanther.Database;

namespace PinkPanther.Core
{
    public class DateOnlyConverter : IValueConverter<DateTime, DateOnly>
    {
        public DateOnly Convert(DateTime sourceMember, ResolutionContext context)
        {
            return DateOnly.FromDateTime(sourceMember);
        }
    }

    public class DateTimeConverter : IValueConverter<DateOnly, DateTime>
    {
        public DateTime Convert(DateOnly sourceMember, ResolutionContext context)
        {
            return sourceMember.ToDateTime(TimeOnly.Parse("00:00"));
        }
    }

    public class DtoMapper
    {
        IMapper _mapper;

        public DtoMapper()
        {
            _mapper = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Client, ClientDto>().ForMember(c => c.BirthDate, opt => opt.ConvertUsing(new DateOnlyConverter()));
                opt.CreateMap<ClientDto, Client>().ForMember(c => c.BirthDate, opt => opt.ConvertUsing(new DateTimeConverter()));
                opt.CreateMap<Animal, AnimalDto>().ForMember(c => c.BirthDate, opt => opt.ConvertUsing(new DateOnlyConverter()));
                opt.CreateMap<AnimalDto, Animal>().ForMember(c => c.BirthDate, opt => opt.ConvertUsing(new DateTimeConverter()));
                opt.CreateMap<Database.Type, TypeDto>().ReverseMap();
                opt.CreateMap<Race, RaceDto>().ReverseMap();
            }).CreateMapper();  
        }

        #region ClientMap
        public Client Map(ClientDto clientDto)
            => _mapper.Map<Client>(clientDto);

        public IEnumerable<Client> Map(IEnumerable<ClientDto> clientDtos)
            => _mapper.Map<IEnumerable<Client>>(clientDtos);

        public ClientDto Map(Client client)
            => _mapper.Map<ClientDto>(client);

        public IEnumerable<ClientDto> Map(IEnumerable<Client> clients)
            => _mapper.Map<IEnumerable<ClientDto>>(clients);

        #endregion

        #region AnimalMap
        public Animal Map(AnimalDto animalDto)
            => _mapper.Map<Animal>(animalDto);

        public IEnumerable<Animal> Map(IEnumerable<AnimalDto> animalDtos)
            => _mapper.Map<IEnumerable<Animal>>(animalDtos);

        public AnimalDto Map(Animal animal)
            => _mapper.Map<AnimalDto>(animal);

        public IEnumerable<AnimalDto> Map(IEnumerable<Animal> animals)
            => _mapper.Map<IEnumerable<AnimalDto>>(animals);

        #endregion

        #region TypeMap

        public Database.Type Map(TypeDto typeDto)
            => _mapper.Map<Database.Type>(typeDto);

        public IEnumerable<Database.Type> Map(IEnumerable<TypeDto> typeDtos)
            => _mapper.Map<IEnumerable<Database.Type>>(typeDtos);

        public TypeDto Map(Database.Type type)
            => _mapper.Map<TypeDto>(type);

        public IEnumerable<TypeDto> Map(IEnumerable<Database.Type> types)
            => _mapper.Map<IEnumerable<TypeDto>>(types);

        #endregion

        #region RaceMap
        public Race Map(RaceDto raceDto)
            => _mapper.Map<Race>(raceDto);

        public IEnumerable<Race> Map(IEnumerable<RaceDto> raceDtos)
            => _mapper.Map<IEnumerable<Race>>(raceDtos);

        public RaceDto Map(Race race)
            => _mapper.Map<RaceDto>(race);

        public IEnumerable<RaceDto> Map(IEnumerable<Race> races)
            => _mapper.Map<IEnumerable<RaceDto>>(races);
        #endregion
    }
}
