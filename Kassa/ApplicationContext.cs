using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kassa;

namespace WpfApp2
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Station> Stations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlite(@"Data Source=C:\Users\BeVL\source\repos\Kassa\Kassa\Kassa.db");
        }
    }
}
