using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        public LeagueRepository()
        {
        }

        public IList<League> GetLeaguesBySeasonId(int Id)
        {
            try
            {
                return Db.ExecuteReader(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, "GetLeaguesBySeasonId", CommandType.StoredProcedure, 
                new SqlParameter[]
                {
                    new SqlParameter("@Season_Id", Id), 
                }, ParseLeagues);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Leagues from database", ex);
            }
        }

        public int InsertLeague(League league)
        {
            try
            {
                return Db.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "InsertLeague", CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter("@SeasonId", league.Season_Id),
                        new SqlParameter("@Description", league.Description),
                        new SqlParameter("@LeagueLevel", league.LeagueLevel)
                    });
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to add League to the database", ex);
            }
        }
        public int InsertPlayerIntoLeague(int playerId, int leagueId)
        {
            try
            {
                return Db.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "InsertLeaguePlayer", CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter("@leagueId", leagueId),
                        new SqlParameter("@playerId", playerId)
                    });
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to add player to the league", ex);
            }
        }

        public static IList<Player> GetPlayersByLeague(int LeagueId)
        {
            try
            {
                return Db.ExecuteReader(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, "GetPlayersByLeagueId", CommandType.StoredProcedure,
                new SqlParameter[]
                {
                    new SqlParameter("@LeagueId", LeagueId),
                }, PlayerRepository.ParsePlayers);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Leagues from database", ex);
            }
        }

        public static IList<Results> GetResultsByLeague(int LeagueId)
        {
            try
            {
                return Db.ExecuteReader(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, "GetResultsByLeagueId", CommandType.StoredProcedure,
                new SqlParameter[]
                {
                    new SqlParameter("@League_Id", LeagueId),
                }, ParseResults);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Results from database", ex);
            }
        }

        private static IList<Match> GetMatchesByLeagueId(int leagueId)
        {
            try
            {
                return Db.ExecuteReader(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, "GetMatchesByLeagueId", CommandType.StoredProcedure, new SqlParameter[]
                {
                    new SqlParameter("@League_Id", leagueId),
                }, MatchRepository.ParseMatches);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Matchs from database", ex);
            }
        }

        private static IList<Results> ParseResults(SqlDataReader reader)
        {
            var results = new List<Results>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Results
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Wins = reader.IsDBNull(reader.GetOrdinal("Wins")) ? (int?)0 : reader.GetInt32(reader.GetOrdinal("Wins")),
                        Losses = reader.IsDBNull(reader.GetOrdinal("Losses")) ? (int?)0 : reader.GetInt32(reader.GetOrdinal("Losses"))
                    });
                }
            }

            return results;
        }

        private static List<League> ParseLeagues(SqlDataReader reader)
        {
            var results = new List<League>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new League
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Season_Id = reader.GetInt32(reader.GetOrdinal("Season_Id")),
                        Description= reader.GetString(reader.GetOrdinal("Description")),
                        LeagueLevel = reader.GetInt32(reader.GetOrdinal("LeagueLevel")),
                        Players = GetPlayersByLeague(reader.GetInt32(reader.GetOrdinal("ID"))),
                        LeagueResults = GetResultsByLeague(reader.GetInt32(reader.GetOrdinal("ID"))),
                        Matches = GetMatchesByLeagueId(reader.GetInt32(reader.GetOrdinal("ID")))
                    });
                }
            }

            return results;
        }
    }
}