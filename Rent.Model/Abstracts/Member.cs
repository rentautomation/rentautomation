using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Abstracts
{
    public abstract class Member
    {
        public Member() { }
        public int membernumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public int  age{ get; set; }
        public int isactive { get; set; }

    }
}
