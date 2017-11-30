using System;
using System.Collections.Generic;
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
                return Db.ExecuteReader("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True", "GetLeaguesBySeasonId", CommandType.StoredProcedure, 
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
                return Db.ExecuteNonQuery("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True",
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
                        LeagueLevel = reader.GetInt32(reader.GetOrdinal("LeagueLevel"))
                    });
                }
            }

            return results;
        }
    }
}