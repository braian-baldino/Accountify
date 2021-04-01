using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Vehicle : BaseEntity
    {
        [ForeignKey("AnualBalances")]
        public int AnualBalanceId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Patent { get; set; }
        public List<VehicleSpending> VehicleSpendings { get; set; } = new List<VehicleSpending>();
        public double SpendingsAmount { get; set; }

    }
}
