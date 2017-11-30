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
        IList<Match> GenerateMatches(int LeagueId, IList<int> playerIds, int numberOfMatches = 1, IList<Match> matches = null);
    }
}