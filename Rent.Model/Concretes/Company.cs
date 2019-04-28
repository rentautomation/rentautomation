using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class Company
    {
        public int companynumber { get; set; }
        public string companyname { get; set; }
        public string city { get; set; }
        public int addressnumber { get; set; }
        public int vehiclecount { get; set; }
        public int rate { get; set; }
        public int isactive { get; set; }
    }
}
