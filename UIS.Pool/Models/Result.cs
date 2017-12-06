using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class Results
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Losses { get; set; }
        public int? Wins { get; set; }
    }
}