using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Savings : BaseEntity
    {
        [ForeignKey("AnualBalance")]
        public int AnualBalanceId { get; set; }
        public AnualBalance AnualBalance { get; set; }
        public ESavingType Type { get; set; }
        public double Amount { get; set; }

    }
}
