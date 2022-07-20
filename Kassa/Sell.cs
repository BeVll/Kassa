using System;

namespace Kassa
{
    public class Sell
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Plackart_Count { get; set; }
        public int Kupe_Count { get; set; }
        public int Lux_Count { get; set; }
        public int Train_ID { get; set; }
        public string StartStat { get; set; }
        public string LastStat { get; set; }

        public DateTime DateOfSale { get; set; }
        public double Price { get; set; }
        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public Sell(int iD, int user_ID, int plackart_Count, int kupe_Count, int lux_Count, int train_ID, string startStat, string lastStat, DateTime dateOfSale, double price, DateTime departure, DateTime arrival)
        {
            ID = iD;
            User_ID = user_ID;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            Train_ID = train_ID;
            StartStat = startStat;
            LastStat = lastStat;
            DateOfSale = dateOfSale;
            Price = price;
            Departure = departure;
            Arrival = arrival;
        }
        public Sell(int user_ID, int plackart_Count, int kupe_Count, int lux_Count, int train_ID, string startStat, string lastStat, DateTime dateOfSale, double price, DateTime departure, DateTime arrival)
        {
            User_ID = user_ID;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            Train_ID = train_ID;
            StartStat = startStat;
            LastStat = lastStat;
            DateOfSale = dateOfSale;
            Price = price;
            Departure = departure;
            Arrival = arrival;
        }
    }
}
