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

        public List<ClientViewModel> Map(List<ClientDto> clientDtos)
            => _mapper.Map<List<ClientViewModel>>(clientDtos);

        public ClientDto Map(ClientViewModel client)
            => _mapper.Map<ClientDto>(client);

        public List<ClientDto> Map(List<ClientViewModel> clients)
            => _mapper.Map<List<ClientDto>>(clients);

        #endregion

        #region AnimalMap
        public AnimalViewModel Map(AnimalDto animalDto)
            => _mapper.Map<AnimalViewModel>(animalDto);

        public List<AnimalViewModel> Map(List<AnimalDto> animalDtos)
            => _mapper.Map<List<AnimalViewModel>>(animalDtos);

        public AnimalDto Map(AnimalViewModel animal)
            => _mapper.Map<AnimalDto>(animal);

        public List<AnimalDto> Map(List<AnimalViewModel> animals)
            => _mapper.Map<List<AnimalDto>>(animals);

        #endregion

        #region TypeMap

        public TypeViewModel Map(TypeDto typeDto)
            => _mapper.Map<TypeViewModel>(typeDto);

        public List<TypeViewModel> Map(List<TypeDto> typeDtos)
            => _mapper.Map<List<TypeViewModel>>(typeDtos);

        public TypeDto Map(TypeViewModel type)
            => _mapper.Map<TypeDto>(type);

        public List<TypeDto> Map(List<TypeViewModel> types)
            => _mapper.Map<List<TypeDto>>(types);

        #endregion

        #region RaceMap
        public RaceViewModel Map(RaceDto raceDto)
            => _mapper.Map<RaceViewModel>(raceDto);

        public List<RaceViewModel> Map(List<RaceDto> raceDtos)
            => _mapper.Map<List<RaceViewModel>>(raceDtos);

        public RaceDto Map(RaceViewModel race)
            => _mapper.Map<RaceDto>(race);

        public List<RaceDto> Map(List<RaceViewModel> races)
            => _mapper.Map<List<RaceDto>>(races);
        #endregion
    }
}
