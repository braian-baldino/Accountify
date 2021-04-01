using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Interfaces
{
    public interface ICommonEntity
    {
        [ForeignKey("Balances")]
        int BalanceId { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        double Amount { get; set; }
    }
}
