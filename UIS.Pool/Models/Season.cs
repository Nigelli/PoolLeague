using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIS.Pool.Models
{
    public class Season
    {
        public Season()
        {
            
        }
        public int Id { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<League> Leagues { get; set; }
    }
}