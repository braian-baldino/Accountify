using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class DropdownDto
    {
        public Dictionary<int, string> DropdownDictionary { get; set; } = new Dictionary<int, string>();
    }
}
