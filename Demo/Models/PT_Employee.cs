using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    internal class PT_Employee : Employee
    {
        public int CountOfHour { get; set; }
        public decimal HourRate { get; set; }
    }
}
