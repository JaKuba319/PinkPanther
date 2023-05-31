namespace PinkPanther.Models
{
    public class AnimalRacesViewModel
    {
        public AnimalViewModel Animal { get; set; }
        public IEnumerable<RaceViewModel> Races { get; set; }
    }
}
