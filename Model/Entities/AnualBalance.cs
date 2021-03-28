using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class AnualBalance : BaseEntity
    {
        public List<Balance> Balances { get; set; } = new List<Balance>();
        public int Year { get; set; }
        public double Result { get; set; }
        public bool Positive { get; set; }

    }
}
