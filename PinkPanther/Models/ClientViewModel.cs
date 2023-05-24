namespace PinkPanther.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; } // 0 female, 1 male
        public List<AnimalViewModel> Animals { get; set; }

    }
}
