
using System.Linq;
using WpfApp2;

namespace Kassa
{
    public class Controller
    {
        ApplicationContext bd = new();

        /// <summary>
        /// True - login not exist \ False - login exist in DataBase
        /// </summary>
        public bool Register(string login, string pass)
        {
            if (RegistrationCheck(login))
            {
                bd.Users.Add(new User(login, pass,"User",0));
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// True - login is successful \ False - login is not successful
        /// </summary>
        public User Login(string login, string pass)
        {
            if (LoginCheck(login,pass))
            {
                return bd.Users.Where(s => s.Login == login && s.Password == pass).FirstOrDefault(); ;
            }
            else
                return null;
        }



        private bool RegistrationCheck(string log)
        {
            User ur = bd.Users.Where(l => l.Login == log).FirstOrDefault();

            if (ur == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool LoginCheck(string login, string pass)
        {
            User ur = bd.Users.Where(s => s.Login == login && s.Password == pass).FirstOrDefault();

            if (ur == null)
                return false;
            else
                if (ur.Password == pass)
                    return true;
                else
                    return false;
        }




    }
}
