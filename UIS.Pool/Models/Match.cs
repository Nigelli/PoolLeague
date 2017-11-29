using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public string Winner { get; set; }
        public int WinnerId { get; set; }
    }
}