namespace PinkPanther.Models
{
    public class AnimalViewModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Race { get; set; }
        public bool Sex { get; set; } // 0 female, 1 male
        public bool IsAdopted { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
