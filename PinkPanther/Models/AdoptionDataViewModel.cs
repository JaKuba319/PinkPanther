namespace PinkPanther.Models
{
    public class AdoptionDataViewModel
    {
        public List<AnimalViewModel> Animals { get; set; }
        public List<ClientViewModel> Clients { get; set; }
        public AnimalViewModel? SelectedAnimal { get; set; }
    }
}
