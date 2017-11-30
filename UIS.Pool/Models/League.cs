using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class League
    {
        public int Id { get; set; }
        public int Season_Id { get; set; }
        public string Description { get; set; }
        public int LeagueLevel { get; set; }
        public virtual ICollection<LeaguePlayer> Players { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}