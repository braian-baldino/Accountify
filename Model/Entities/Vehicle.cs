using System.Collections.Generic;
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
        public List<Spending> VehicleSpendings { get; set; } = new List<Spending>();
        public double Amount { get; set; }

    }
}
