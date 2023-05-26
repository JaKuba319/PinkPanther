namespace PinkPanther.Core
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public List<AnimalDto>? Animals { get; set; }
    }
}
