using Rent.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class Personnel: Member
    {
        public int personnelnumber { get; set; }
        public int companynumber { get; set; }
    }
}
