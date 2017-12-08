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
    public class MatchService: IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            Assertions.IsNullOrDefault(matchRepository, "ILeagueRepository cannot be null.");

            _matchRepository = matchRepository;
        }
        public IList<Match> GetMatchesByLeagueId(int leagueId)
        {
            try
            {
                return _matchRepository.GetMatchesByLeagueId(leagueId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertOrUpdateMatch(Match match)
        {
            try
            {
                match.ObjectNotFound("name cannot be null or whitespace.");
                return _matchRepository.InsertOrUpdateMatch(match);
            }
            catch (ObjectNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertMatches(IList<Match> matches)
        {
            Assertions.IsNullOrEmptyCollection(matches, "At least 1 Match is required");
            try
            {
                return _matchRepository.InsertMatches(matches);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to insert matches into the repository", ex);
            }
        }

        public IList<Match> GenerateMatches(int LeagueId, IList<Player> players = null, int numberOfMatches = 2, IList<Match> matches = null)
        {
            Assertions.IsNullOrDefault(LeagueId, "LeagueId cannot be null");
            try
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}