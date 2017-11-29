using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Services
{
    public interface IMatchService
    {
        IList<Match> GetMatchesByLeagueId(int leagueId);
        int InsertOrUpdateMatch(Match match);
    }
}