
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

        public Sell(int user_ID, int plackart_Count, int kupe_Count, int lux_Count, int train_ID, string startStat, string lastStat)
        {
            User_ID = user_ID;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            Train_ID = train_ID;
            StartStat = startStat;
            LastStat = lastStat;
        }
        public Sell(int id, int user_ID, int plackart_Count, int kupe_Count, int lux_Count, int train_ID, string startStat, string lastStat)
        {
            ID = id;
            User_ID = user_ID;
            Plackart_Count = plackart_Count;
            Kupe_Count = kupe_Count;
            Lux_Count = lux_Count;
            Train_ID = train_ID;
            StartStat = startStat;
            LastStat = lastStat;
        }
    }
}
