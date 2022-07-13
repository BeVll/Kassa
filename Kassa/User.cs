using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassa
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public User(string login, string password, string type, double balance)
        {
            Login = login;
            Password = password;
            Type = type;
            Balance = balance;
        }
    }
}
