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

        public IList<Match> GenerateMatches(int LeagueId, IList<int> playerIds, int numberOfMatches = 1, IList<Match> matches = null)
        {

            matches = matches ?? new List<Match>();

            if (playerIds.Count() <= 1)
            {
                return matches;
            }

            for (int n = 0; n < numberOfMatches; n++)
            {
                for (int i = 1; i < playerIds.Count(); i++)
                {
                    var match = new Match()
                    {
                        LeagueId = LeagueId,
                        Player1 = playerIds[0],
                        Player2 = playerIds[i]
                    };
                    matches.Add(match);
                }
            }

            playerIds.RemoveAt(0);

            return GenerateMatches(LeagueId, playerIds, numberOfMatches, matches);
        }
    }
}