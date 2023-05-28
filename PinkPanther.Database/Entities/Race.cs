using System.ComponentModel.DataAnnotations.Schema;

namespace PinkPanther.Database
{
    public class Race : BaseEntity
    {
        public string RaceName { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual Type Type { get; set; }
    }
}
