using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        public SeasonRepository()
        {
        }

        public IList<Season> GetSeasons()
        {
            try
            {
                return Db.ExecuteReader("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True", "GetSeasons", CommandType.StoredProcedure, new SqlParameter[] { }, ParseSeasons);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Seasons from database", ex);
            }
        }

        public int InsertSeason(string description)
        {
            try
            {
                return Db.ExecuteNonQuery("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True",
                    "InsertSeason", CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter("@Description", description)
                    });
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to add Season to the database", ex);
            }
        }

        private static IList<Season> ParseSeasons(SqlDataReader reader)
        {
            var results = new List<Season>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Season
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Description = reader.GetString(reader.GetOrdinal("Description"))
                    });
                }
            }

            return results;
        }
    }
}