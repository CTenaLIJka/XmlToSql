using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoccerContext db = new SoccerContext())
            {
                // создание и добавление моделей
                Team t1 = new Team { Name = "Барселона" };
                Team t2 = new Team { Name = "Реал Мадрид" };
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();
                Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий", Team = t2 };
                Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий", Team = t1 };
                Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник", Team = t1 };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();               
            }
            
        }
    }
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public ICollection<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }
    
}
