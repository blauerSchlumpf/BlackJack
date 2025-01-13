using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    public class LeaderboardData
    {
        public string Username { get; set; }
        public int Budget { get; set; }
        public int Games_won { get; set; }
        public int Games_lost { get; set; }
        public double Success_rate { get; set; }

        public LeaderboardData(string username, int budget, int games_won, int games_lost, double success_rate)
        {
            Username = username;
            Budget = budget;
            Games_won = games_won;
            Games_lost = games_lost;
            Success_rate = success_rate;
        }
    }
}
