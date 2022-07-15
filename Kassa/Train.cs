using System;

namespace Kassa
{
    public class Train
    {
        public int ID { get; set; }
        public string Stations { get; set; }
        public DateTime dateTime { get; set; }
        public int Plackart_Count { get; set; }
        public int Kupe_Count { get; set; }
        public int Lux_Count { get; set; }
        ..

        public Train(string Stations, DateTime dateTime, int Plackart, int Kupe, int Lux)
        {
            this.Stations = Stations;
            this.dateTime = dateTime;
            this.Plackart_Count = Plackart;
            this.Kupe_Count = Kupe;
            this.Lux_Count = Lux;
        }
    }
}
