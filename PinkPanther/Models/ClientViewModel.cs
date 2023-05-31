using System.ComponentModel.DataAnnotations;

namespace PinkPanther.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings=false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        public string? Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public bool Gender { get; set; }

        public IEnumerable<AnimalViewModel>? Animals { get; set; }

    }
}
