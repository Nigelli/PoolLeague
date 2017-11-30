using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Services
{
    public interface ILeagueService
    {
        IList<League> GetLeaguesBySeasonId(int Id);
        int InsertLeague(League league);
        int InsertPlayerIntoLeague(int playerId, int LeagueId);
    }
}