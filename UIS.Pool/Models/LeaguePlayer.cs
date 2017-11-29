using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class LeaguePlayer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
    }
}