using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageSearch.Model
{
    public class FlightSearchCriteria
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
