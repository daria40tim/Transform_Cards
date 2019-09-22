using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Model
{
    public class Card
    {
        public int CardId { get; set; }
        public string Type { get; set; }
        public float Power { get; set; }
        public Voltage Pr_Voltage { get; set; }
        public List<Voltage> Sec_Voltage { get; set; }
        public bool IsShielded { get; set; }
        public DateTime DateofCreation { get; set; }
        public Worker Author { get; set;}
        public bool Bid { get; set; }
        public bool IsNotTested { get; set; }
        public string Picture { get; set; }
        public string CardFile { get; set; }
        public string Addition { get; set; }
        public string ConnectionType { get; set; }
        public int NumberofCoils { get; set; }
        public string PowerMeasure { get; set; }
    }
}
