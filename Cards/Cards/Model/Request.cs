using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Model
{
    public class Request
    {
        public int ReqId { get; set; }
        public DateTime ReqDate { get; set; }
        public string Document { get; set; }
        public int Number { get; set; }
    }
}
