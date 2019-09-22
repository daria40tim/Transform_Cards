using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Model
{
    public class Voltage
    {
        private Collection<int> _Values;
        public Collection<int> Values { get; set; }
        public Voltage(string[] volt)
        {
            Values = new Collection<int>();
            foreach (var item in volt)
            {
                Values.Add(int.Parse(item));
            }
        }
    }
}
