namespace PinkPanther.Core
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public bool IsVaccinated { get; set; }
        public TypeDto Type { get; set; }
        public RaceDto Race { get; set; }
        public ClientDto Client { get; set; }
    }
}
