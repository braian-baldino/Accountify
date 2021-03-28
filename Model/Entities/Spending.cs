using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Spending : BaseEntity
    {
        [ForeignKey("Balance")]
        public int BalanceId { get; set; }
        public ESpendingCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
