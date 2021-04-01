using Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Savings : BaseEntity
    {
        [ForeignKey("AnualBalances")]
        public int AnualBalanceId { get; set; }
        public ESavingType Type { get; set; }
        public double Amount { get; set; }

    }
}
