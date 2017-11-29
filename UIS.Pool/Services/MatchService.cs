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
    public class MatchService: IMatchService
    {
        private readonly IMatchRepository _MatchRepository;

        public MatchService(IMatchRepository MatchRepository)
        {
            _MatchRepository = MatchRepository;
        }
        public IList<Match> GetMatchesByLeagueId(int leagueId)
        {
            try
            {
                return _MatchRepository.GetMatchesByLeagueId(leagueId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertOrUpdateMatch(Match match)
        {
            return _MatchRepository.InsertOrUpdateMatch(match);
        }
    }
}