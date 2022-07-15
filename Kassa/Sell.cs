
namespace Kassa
{
    public class Sell
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public int Train_ID { get; set; }


        public Sell(int User_ID, string Type, int Count, int Train_ID)
        {
            this.User_ID = User_ID;
            this.Type = Type;
            this.Count = Count;
            this.Train_ID = Train_ID;
        }

    }
}
