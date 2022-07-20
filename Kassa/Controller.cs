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

        public List<TrainUPD> SetTopTrains()
        {
            List<Train> list = new List<Train>();
            list = bd.Trains.ToList();
          
            list.OrderByDescending(s => s.CountSell);
            List<TrainUPD> list2 = new List<TrainUPD>();
            foreach (Train t in list)
                list2.Add(ToTrainUPD(t));
            if(list2.Count < 5)
                return list2.GetRange(0, list2.Count);
            else
                return list2.GetRange(0, 5);
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

        public string GetStationsStr(List<StationUPD> stationUPDs)
        {
            string str = string.Empty;
            foreach (StationUPD stat in stationUPDs)
            {
                if (str == string.Empty)
                    str = Convert.ToString(stat.ID);
                else
                    str += "-" + stat.ID;
                

            }
            return str;
        }

        public List<StationUPD> GetStationsOnRoute(string stations, string stationstime, string date)
        {
            List<int> list = stations.Split('-').Select(x => Convert.ToInt32(x)).ToList();
            List<Station> sts = new List<Station>();
            List<string> times = stationstime.Split('|').ToList();

            foreach (int i in list)
            {
                sts.Add(bd.Stations.Where(s => s.ID == i).FirstOrDefault());
            }
            DateTime dt = Convert.ToDateTime(date);
            List<StationUPD> stationUPDs = new List<StationUPD>();
            DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day);
            for (int i = 0; i < sts.Count; i++)
            {
                List<string> sttime = times[i].Split('-').ToList();
                List<string> timestr = new List<string>();
                if (i != sts.Count - 1)
                    timestr = sttime[1].Split(':').ToList();
                else if(i == sts.Count - 1)
                    timestr = sttime[0].Split(':').ToList();
                if (i == 0) {
                    dt = dt.AddHours(Convert.ToInt32(timestr[0]));
                    dt = dt.AddMinutes(Convert.ToInt32(timestr[1]));
                }
                else
                {
                    dt2 = new DateTime(dt.Year, dt.Month, dt.Day);

                    dt2 = dt2.AddHours(Convert.ToInt32(timestr[0]));
                    dt2 = dt2.AddMinutes(Convert.ToInt32(timestr[1]));
                    if (dt2 < dt)
                        dt2 = dt2.AddDays(1);

                }
                stationUPDs.Add(new StationUPD(sts[i].ID, sts[i].Name, sttime[0], sttime[1], dt2.ToShortDateString()));
            }
            return stationUPDs;
        }

       

        public List<Station> ToStations(List<StationUPD> stationUPDs)
        {
            List<Station> stations = new List<Station>();
            string sts = string.Empty;
            foreach(StationUPD stat in stationUPDs)
                stations.Add(new Station(stat.ID, stat.Name));
            return stations;
        }

        public bool AddSell(int plac, int kupe, int lux, int user_id, int train_id, string Start, string Last)
        {
            Train train = bd.Trains.Where(s => s.ID == train_id).FirstOrDefault();
            if (train.Plackart_Count >= plac && train.Kupe_Count >= kupe && train.Lux_Count >= lux)
            {
                Sell sell = new Sell(user_id, plac, kupe, lux, train_id, Start, Last);
                train.Plackart_Count -= sell.Plackart_Count;
                train.Kupe_Count -= sell.Kupe_Count;
                train.Lux_Count -= sell.Lux_Count;
                bd.Trains.Update(train);
                bd.Sell.Add(sell);
                bd.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public string GetStationsTimeOnRoute(List<StationUPD> stationUPDs)
        {
            string sts = string.Empty;
            foreach (StationUPD stat in stationUPDs)
            {
                if (sts == string.Empty)
                    sts = stat.Arrival;
                else
                    sts += "|" + stat.Arrival;
                sts += "-" + stat.Departure;

            }
            return sts;
        }

        public List<Train> GetTrains()
        {
            return bd.Trains.ToList();
        }

        public Train ToTrain(TrainUPD trainUPD)
        {
   
            string stats = GetStationsStr(trainUPD.Stations);
            string times = GetStationsTimeOnRoute(trainUPD.Stations);
            Train train = new Train(trainUPD.ID, trainUPD.Number, trainUPD.FirstStation, trainUPD.LastStation, stats, times, trainUPD.Data, trainUPD.Plackart_Count, trainUPD.Kupe_Count, trainUPD.Lux_Count, trainUPD.CountSell);
            return train;
        }

        public TrainUPD ToTrainUPD(Train train)
        {

            List <StationUPD> stationUPDs = GetStationsOnRoute(train.Stations, train.StationsTime, train.Data);
            TrainUPD trainUPD = new TrainUPD(train.ID, train.Number, train.FirstStation, train.LastStation, stationUPDs, train.Data, train.Plackart_Count, train.Kupe_Count, train.Lux_Count, train.CountSell, Convert.ToDateTime(stationUPDs[0].Date), Convert.ToDateTime(stationUPDs[stationUPDs.Count-1].Date));
            return trainUPD;
        }

        public List<TrainUPD> GetFoundTrains(string StartS, string LastS, string Date)
        {
            List<Train> trains = bd.Trains.ToList();
            List<TrainUPD> foundTrains = new List<TrainUPD>();
            foreach(Train t in trains)
                foundTrains.Add(ToTrainUPD(t));

            foundTrains = foundTrains.Where(s => s.Stations.Find(x => x.Name == StartS) != null).ToList();
            List<TrainUPD> foundTrainsLast = new List<TrainUPD>();
            foundTrainsLast.AddRange(foundTrains);
            foreach (TrainUPD trainUPD in foundTrains)
            {
                StationUPD s1 = trainUPD.Stations.Find(s => s.Name == StartS);
                
                if (s1 != null)
                {
                    trainUPD.Departure = Convert.ToDateTime(s1.Date + " " + s1.Departure);
                    int index = trainUPD.Stations.IndexOf(s1);
                    trainUPD.Stations.RemoveRange(0, index + 1);
                    StationUPD s = trainUPD.Stations.Find(s => s.Name == LastS);
                    if (s == null)
                    {
                        foundTrainsLast.Remove(trainUPD);
                    }
                    else
                    {
                        trainUPD.Arrival = Convert.ToDateTime(s.Date + " " + s.Arrival);
                        if (Convert.ToDateTime(s1.Date) != Convert.ToDateTime(Date))
                        {
                            foundTrainsLast.Remove(trainUPD);
                        }
                    }
                }
                else
                    foundTrainsLast.Remove(trainUPD);
            }
            return foundTrainsLast;
        }
    }
}
