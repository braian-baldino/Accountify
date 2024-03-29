﻿using Model.Enums;
using Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Income : BaseEntity, ICommonEntity
    {
        public EIncomeCategory Category { get; set; }
        [ForeignKey("Balances")]
        public int BalanceId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
