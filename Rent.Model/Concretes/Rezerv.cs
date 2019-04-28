using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class Rezerv
    {
        public int rezervnumber { get; set; }
        public int membernumber { get; set; }
        public int vehiclenumber { get; set; }
        public DateTime rezervdate { get; set; }
        public int isactive { get; set; }
    }
}
