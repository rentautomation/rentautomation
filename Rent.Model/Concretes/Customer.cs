using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Model.Abstracts;

namespace Rent.Model.Concretes
{
    public class Customer: Member
    {
        public int customernumber { get; set; }
    }
}
