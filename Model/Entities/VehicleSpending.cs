using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class VehicleSpending : BaseEntity
    {
        [ForeignKey("Vehicles")]
        public int VehicleId { get; set; }
        public EVehicleSpendingCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
