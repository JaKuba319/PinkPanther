using System.ComponentModel.DataAnnotations.Schema;

namespace PinkPanther.Database
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public bool IsVaccinated { get; set; }

        [ForeignKey("Race")]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }

    }
}
