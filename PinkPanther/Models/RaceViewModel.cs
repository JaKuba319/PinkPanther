using System.ComponentModel.DataAnnotations;

namespace PinkPanther.Models
{
    public class RaceViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RaceName { get; set; }

        public TypeViewModel? Type { get; set; }
    }
}
