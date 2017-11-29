using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class Match
    {
        public int? Id { get; set; }
        public int LeagueId { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int? Winner { get; set; }
    }
}