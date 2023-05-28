namespace PinkPanther.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Gender { get; set; } // 0 female, 1 male
        public bool IsVaccinated { get; set; }
        public RaceViewModel Race { get; set; }
        public ClientViewModel? Client { get; set; }
        
    }
}
