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
using UIS.Pool.Utilities;

namespace UIS.Pool.Services
{
    public class LeagueService: ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueService(ILeagueRepository leagueRepository)
        {
            Assertions.IsNullOrDefault(leagueRepository, "ILeagueRepository cannot be null.");

            _leagueRepository = leagueRepository;
        }
        public IList<League> GetLeaguesBySeasonId(int Id)
        {
            try
            {
                return _leagueRepository.GetLeaguesBySeasonId(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertLeague(League league)
        {
            try
            {
                return _leagueRepository.InsertLeague(league);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertPlayerIntoLeague(int playerId, int LeagueId)
        {
            try
            {
                return _leagueRepository.InsertPlayerIntoLeague(playerId, LeagueId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}