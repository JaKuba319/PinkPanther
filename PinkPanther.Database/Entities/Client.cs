namespace PinkPanther.Database
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }

        public virtual IEnumerable<Animal> Animals { get; set; }
    }
}
