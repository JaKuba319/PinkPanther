namespace PinkPanther.Models
{
    public class ClientViewModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Sex { get; set; } // 0 female, 1 male
        public DateOnly BirthDate { get; set; }
        public List<AnimalViewModel>? Animals { get; set; }

        //email
    }
}
