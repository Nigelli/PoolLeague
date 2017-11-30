using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {
        }

        public IList<Player> GetPlayers()
        {
            try
            {
                return Db.ExecuteReader("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True", "GetPlayers", CommandType.StoredProcedure, new SqlParameter[] { }, ParsePlayers);
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to get Players from database", ex);
            }
        }

        public int InsertPlayer(string name)
        {
            try
            {
                return Db.ExecuteNonQuery("Data Source=localhost;Initial Catalog=UIS.Pool;Integrated Security=True",
                    "InsertPlayer", CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter("@Name", name)
                    });
            }
            catch (Exception ex)
            {
                throw new DataException("Failure to add Player to the database", ex);
            }
        }

        public static IList<Player> ParsePlayers(SqlDataReader reader)
        {
            var results = new List<Player>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(new Player
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Name = reader.GetString(reader.GetOrdinal("Name"))
                    });
                }
            }

            return results;
        }
    }
}