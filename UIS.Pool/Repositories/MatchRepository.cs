using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public MatchRepository()
        {
        }

        public IList<Match> GetMatchesByLeagueId(int leagueId)
        {
            try
            {
                return Db.ExecuteReader("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True", "GetMatchesByLeagueId", CommandType.StoredProcedure, new SqlParameter[]
                {
                    new SqlParameter("@League_Id", leagueId), 
                }, ParseMatches);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Matchs from database", ex);
            }
        }

        public int InsertOrUpdateMatch(Match match)
        {
            try
            {
                return Db.ExecuteNonQuery("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True",
                    "InsertOrUpdateMatch", CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter("@Id", match.Id),
                        new SqlParameter("@Player1", match.Player1),
                        new SqlParameter("@Player2", match.Player2),
                        new SqlParameter("@Winner", match.Winner),
                        new SqlParameter("@League_Id", match.LeagueId)
                    });
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to add Match to the database", ex);
            }
        }

        public int InsertMatches(IList<Match> matches)
        {
            try
            {
                try
                {
                    var newMatches = new DataTable();
                    newMatches.Columns.Add("LeagueId", typeof(int));
                    newMatches.Columns.Add("Player1", typeof(int));
                    newMatches.Columns.Add("Player2", typeof(int));
                    foreach (var match in matches)
                    {
                        DataRow dataRow = newMatches.NewRow();

                        dataRow["LeagueId"] = match.LeagueId;
                        dataRow["Player1"] = match.Player1;
                        dataRow["Player2"] = match.Player2;
                        newMatches.Rows.Add(dataRow);
                    }

                    return Db.ExecuteNonQuery("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True", 
                    "InsertMatches", CommandType.StoredProcedure, new SqlParameter[]
                        {
                        new SqlParameter("@matches", newMatches)
                        });
                }
                catch (Exception ex)
                {
                    throw new DataException("Failure to Execute command: InsertOrUpdateUser.", ex);
                }
            }
            catch (Exception ex)
            {
                if (ex is DataException)
                    throw;

                throw new DataException("Failure to Insert Or Update Policies into the repository.", ex);
            }
        }

        private static IList<Match> ParseMatches(SqlDataReader reader)
        {
            var results = new List<Match>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Match
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        LeagueId = reader.GetInt32(reader.GetOrdinal("League_Id")),
                        Player1 = reader.GetInt32(reader.GetOrdinal("Player1")),
                        Player2 = reader.GetInt32(reader.GetOrdinal("Player2")),
                        Winner = reader.GetInt32(reader.GetOrdinal("Winner")),
                    });
                }
            }

            return results;
        }
    }
}