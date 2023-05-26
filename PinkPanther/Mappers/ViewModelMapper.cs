using AutoMapper;
using PinkPanther.Core;
using PinkPanther.Models;

namespace PinkPanther.Mappers
{
    public class ViewModelMapper
    {
        IMapper _mapper;

        public ViewModelMapper()
        {
            _mapper = new MapperConfiguration(opt =>
            {
                opt.CreateMap<AnimalDto, AnimalViewModel>().ReverseMap();
                opt.CreateMap<ClientDto, ClientViewModel>().ReverseMap();
                opt.CreateMap<TypeDto, TypeViewModel>().ReverseMap();
                opt.CreateMap<RaceDto, RaceViewModel>().ReverseMap();
            }).CreateMapper();
        }

        #region ClientMap
        public ClientViewModel Map(ClientDto clientDto)
            => _mapper.Map<ClientViewModel>(clientDto);

        public IEnumerable<ClientViewModel> Map(IEnumerable<ClientDto> clientDtos)
            => _mapper.Map<IEnumerable<ClientViewModel>>(clientDtos);

        public ClientDto Map(ClientViewModel client)
            => _mapper.Map<ClientDto>(client);

        public IEnumerable<ClientDto> Map(IEnumerable<ClientViewModel> clients)
            => _mapper.Map<IEnumerable<ClientDto>>(clients);

        #endregion

        #region AnimalMap
        public AnimalViewModel Map(AnimalDto animalDto)
            => _mapper.Map<AnimalViewModel>(animalDto);

        public IEnumerable<AnimalViewModel> Map(IEnumerable<AnimalDto> animalDtos)
            => _mapper.Map<IEnumerable<AnimalViewModel>>(animalDtos);

        public AnimalDto Map(AnimalViewModel animal)
            => _mapper.Map<AnimalDto>(animal);

        public IEnumerable<AnimalDto> Map(IEnumerable<AnimalViewModel> animals)
            => _mapper.Map<IEnumerable<AnimalDto>>(animals);

        #endregion

        #region TypeMap

        public TypeViewModel Map(TypeDto typeDto)
            => _mapper.Map<TypeViewModel>(typeDto);

        public IEnumerable<TypeViewModel> Map(IEnumerable<TypeDto> typeDtos)
            => _mapper.Map<IEnumerable<TypeViewModel>>(typeDtos);

        public TypeDto Map(TypeViewModel type)
            => _mapper.Map<TypeDto>(type);

        public IEnumerable<TypeDto> Map(IEnumerable<TypeViewModel> types)
            => _mapper.Map<IEnumerable<TypeDto>>(types);

        #endregion

        #region RaceMap
        public RaceViewModel Map(RaceDto raceDto)
            => _mapper.Map<RaceViewModel>(raceDto);

        public IEnumerable<RaceViewModel> Map(IEnumerable<RaceDto> raceDtos)
            => _mapper.Map<IEnumerable<RaceViewModel>>(raceDtos);

        public RaceDto Map(RaceViewModel race)
            => _mapper.Map<RaceDto>(race);

        public IEnumerable<RaceDto> Map(IEnumerable<RaceViewModel> races)
            => _mapper.Map<IEnumerable<RaceDto>>(races);
        #endregion
    }
}
