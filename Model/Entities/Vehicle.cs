using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Vehicle : BaseEntity
    {
        [ForeignKey("AnualBalance")]
        public int AnualBalanceId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Patent { get; set; }

    }
}
