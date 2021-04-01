using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Income : BaseEntity
    {
        [ForeignKey("Balances")]
        public int BalanceId { get; set; }
        public EIncomeCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
