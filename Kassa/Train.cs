using System;

namespace Kassa
{
    public class Train
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public string Stations { get; set; }
        public string StationsTime { get; set; }
        public string Data { get; set; }
        public int Plackart_Count { get; set; }
        public int Kupe_Count { get; set; }
        public int Lux_Count { get; set; }
        public int CountSell { get; set; }

        public Train(string number, string firstStation, string lastStation, string stations, string stationsTime, string data, int plackart_Count, int kupe_Count, int lux_Count, int countSell)
        {
            Number = number;
            FirstStation = firstStation;
            LastStation = lastStation;
            Stations = stations;
            StationsTime = stationsTime;
            Data = data;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            CountSell = countSell;
        }


        public Train(int id, string number, string firstStation, string lastStation, string stations, string stationsTime, string data, int plackart_Count, int kupe_Count, int lux_Count, int countSell)
        {
            ID = id;
            Number = number;
            FirstStation = firstStation;
            LastStation = lastStation;
            Stations = stations;
            StationsTime = stationsTime;
            Data = data;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            CountSell = countSell;
        }
    }
}
