using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class Address
    {
        public int addressnumber { get; set; }
        public string district { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public int buildnumber { get; set; }
        public int isactive { get; set; }
    }
}
