using Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Balance : BaseEntity
    {
        [ForeignKey("AnualBalance")]
        public int AnualBalanceId { get; set; }
        public AnualBalance AnualBalance { get; set; }
        public EMonth Month { get; set; }
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Spending> Spendings { get; set; } = new List<Spending>();
        public double Result { get; set; }
        public bool Positive { get; set; }
    }
}
