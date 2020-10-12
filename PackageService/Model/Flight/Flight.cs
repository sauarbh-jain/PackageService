using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageSearch.Model
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string FlightName { get; set; }
        public SeatClass SeatClass { get; set; }
    }
}

