using System;

namespace Kassa
{
    public class Train
    {
        public int ID { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public string Stations { get; set; }
        public DateTime TimeStart { get; set; }
        public int Plackart_Count { get; set; }
        public int Kupe_Count { get; set; }
        public int Lux_Count { get; set; }
        public int CountSell { get; set; }

        public Train(string firstStation, string lastStation, string stations, DateTime timeStart, int plackart_Count, int kupe_Count, int lux_Count, int countSell)
        {
            FirstStation = firstStation;
            LastStation = lastStation;
            Stations = stations;
            TimeStart = timeStart;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            CountSell = countSell;
        }
    }
}
