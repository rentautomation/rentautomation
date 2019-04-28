using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class RentModel
    {
        public int rentnumber { get; set; }
        public int membernumber { get; set; }
        public int vehiclenumber { get; set; }
        public DateTime rentdatebegin { get; set; }
        public DateTime rentdateend { get; set; }
        public int beginkm { get; set; }
        public int endkm { get; set; }
        public decimal totalprice { get; set; }
        public int isactive { get; set; }
    }
}
