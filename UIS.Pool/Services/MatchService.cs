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

        public int InsertMatches(IList<Match> matches)
        {
            return _MatchRepository.InsertMatches(matches);
        }

        public IList<Match> GenerateMatches(int LeagueId, IList<Player> players = null, int numberOfMatches = 2, IList<Match> matches = null)
        {
            players = players ?? LeagueRepository.GetPlayersByLeague(LeagueId);
            matches = matches ?? new List<Match>();

            if (players.Count() <= 1)
            {
                return matches;
            }

            for (int n = 0; n < numberOfMatches; n++)
            {
                for (int i = 1; i < players.Count(); i++)
                {
                    var match = new Match()
                    {
                        LeagueId = LeagueId,
                        Player1 = players[0].Id,
                        Player2 = players[i].Id
                    };
                    matches.Add(match);
                }
            }

            players.RemoveAt(0);

            return GenerateMatches(LeagueId, players, numberOfMatches, matches);
        }
    }
}