using System.Collections.Generic;

namespace Model.Entities
{
    public class AnualBalance : BaseEntity
    {
        public List<Balance> Balances { get; set; } = new List<Balance>();
        public List<Savings> Savings { get; set; } = new List<Savings>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public int Year { get; set; }
        public double Result { get; set; }
        public bool Positive { get; set; }

    }
}
