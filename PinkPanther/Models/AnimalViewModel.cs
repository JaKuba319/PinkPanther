using System.ComponentModel.DataAnnotations;

namespace PinkPanther.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }

        public RaceViewModel? Race { get; set; }
        public ClientViewModel? Client { get; set; }
        
    }
}
