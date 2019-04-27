using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Model.Concretes
{
    public class Vehicle
    {
        public int vehiclenumber { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public int licenseage { get; set; }
        public int minimumagelimit { get; set; }
        public int dailykmlimit { get; set; }
        public int currentkm { get; set; }
        public bool airbag { get; set; }
        public float trunkvolume { get; set; }
        public int seatcount { get; set; }
        public decimal dailyrentprice { get; set; }
        public int companynumber { get; set; }

    }
}
