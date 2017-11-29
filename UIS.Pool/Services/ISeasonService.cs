using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Services
{
    public interface ISeasonService
    {
        IList<Season> GetSeasons();
        int InsertSeason(string description);
    }
}