using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassa
{
    public class TrainUPD
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public List<StationUPD> Stations { get; set; }
        public string Data { get; set; }
        public int Plackart_Count { get; set; }
        public int Kupe_Count { get; set; }
        public int Lux_Count { get; set; }
        public int CountSell { get; set; }
        public TrainUPD()
        {

        }
        public TrainUPD(string number, string firstStation, string lastStation, List<StationUPD> stations, string timeStart, int plackart_Count, int kupe_Count, int lux_Count, int countSell)
        {
            Number = number;
            FirstStation = firstStation;
            LastStation = lastStation;
            Stations = stations;
            Data = timeStart;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            CountSell = countSell;
        }
        public TrainUPD(int id, string number, string firstStation, string lastStation, List<StationUPD> stations, string timeStart, int plackart_Count, int kupe_Count, int lux_Count, int countSell)
        {
            ID = id;
            Number = number;
            FirstStation = firstStation;
            LastStation = lastStation;
            Stations = stations;
            Data = timeStart;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            CountSell = countSell;
        }
    }
}
