using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public interface ILeagueRepository
    {
        IList<League> GetLeaguesBySeasonId(int Id);
        int InsertLeague(League league);
    }
}
