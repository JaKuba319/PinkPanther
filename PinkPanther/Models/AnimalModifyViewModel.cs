namespace PinkPanther.Models
{
    public class AnimalModifyViewModel
    {
        public AnimalViewModel Animal { get; set; }
        public IEnumerable<TypeViewModel> Types { get; set; }
        public IEnumerable<RaceViewModel> Races { get; set; }
    }
}
