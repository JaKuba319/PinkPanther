namespace PinkPanther.Models
{
    public class AnimalsTypesRacesViewModel
    {
        public IEnumerable<AnimalViewModel>? Animals { get; set; }
        public IEnumerable<TypeViewModel>? Types { get; set; }
        public IEnumerable<RaceViewModel>? Races { get; set; }
    }
}
