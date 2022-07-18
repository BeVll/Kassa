using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassa
{
    public class StationUPD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string Date { get; set; }

        public StationUPD(int id, string Name, string arrival, string departure, string date)
        {
            ID = id;
            this.Name = Name;
            Arrival = arrival;
            Departure = departure;
            Date = date;
        }

    }
}
