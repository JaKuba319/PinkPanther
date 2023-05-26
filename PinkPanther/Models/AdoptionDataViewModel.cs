namespace PinkPanther.Models
{
    public class AdoptionDataViewModel
    {
        public IEnumerable<AnimalViewModel> Animals { get; set; }
        public IEnumerable<ClientViewModel> Clients { get; set; }
        public AnimalViewModel? SelectedAnimal { get; set; }
    }
}
