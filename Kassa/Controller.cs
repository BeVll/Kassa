using System.Collections.Generic;
using System.Linq;
using WpfApp2;
using System.Linq;
using System;

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
                bd.SaveChanges();
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

        public List<Train> SetTopTrains()
        {
            List<Train> list = new List<Train>();
            list = bd.Trains.ToList();
            list.OrderByDescending(s => s.CountSell);
            if(list.Count < 5)
                return list.GetRange(0, list.Count);
            else
                return list.GetRange(0, 5);
        }

        public List<Station> GetStations()
        {
            return bd.Stations.ToList();
        }
        public List<Station> GetStationsOnRoute(string stations)
        {
            List<int> list = stations.Split('-').Select(x => Convert.ToInt32(x)).ToList();
            List<Station> sts = new List<Station>();
            foreach (int i in list)
            {
                sts.Add(bd.Stations.Where(s => s.ID == i).FirstOrDefault());
            }
            return sts;
        }

        public List<Train> GetTrains()
        {
            return bd.Trains.ToList();
        }
    }
}
