
namespace Kassa
{
    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Station(int id, string Name)
        {
            ID = id;
            this.Name = Name;
        }

        public Station(string Name)
        {
            this.Name = Name;
        }

    }
}
