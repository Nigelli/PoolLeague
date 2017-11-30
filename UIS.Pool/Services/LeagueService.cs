using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using UIS.Pool.Models;
using UIS.Pool.Repositories;

namespace UIS.Pool.Services
{
    public class LeagueService: ILeagueService
    {
        private readonly ILeagueRepository _LeagueRepository;

        public LeagueService(ILeagueRepository LeagueRepository)
        {
            _LeagueRepository = LeagueRepository;
        }
        public IList<League> GetLeaguesBySeasonId(int Id)
        {
            try
            {
                return _LeagueRepository.GetLeaguesBySeasonId(Id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertLeague(League league)
        {
            return _LeagueRepository.InsertLeague(league);
        }

        public int InsertPlayerIntoLeague(int playerId, int LeagueId)
        {
            return _LeagueRepository.InsertPlayerIntoLeague(playerId, LeagueId);
        }
    }
}