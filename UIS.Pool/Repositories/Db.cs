using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UIS.Pool.Repositories
{
    public static class Db
    {
        public static IList<T> ExecuteReader<T>(string connectionString, string cmdText, CommandType cmdType, SqlParameter[] parameters,
                Func<SqlDataReader, IList<T>> handler, bool requiresTransaction = false, CommandBehavior behavior = CommandBehavior.CloseConnection, int timeout = 30)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(cmdText, connection))
            {
                command.CommandType = cmdType;
                command.CommandTimeout = timeout;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                SqlTransaction transaction = null;

                try
                {
                    connection.Open();

                    if (requiresTransaction)
                    {
                        transaction = connection.BeginTransaction();
                        command.Transaction = transaction;
                    }

                    var result = handler.Invoke(command.ExecuteReader(behavior));

                    if (requiresTransaction)
                        transaction.Commit();

                    return result;
                }
                catch
                {
                    if (requiresTransaction)
                        transaction?.Rollback();

                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public static int ExecuteNonQuery(string connectionString, string cmdText, CommandType cmdType, SqlParameter[] parameters,
            bool requiresTransaction = false, int timeout = 30)
        {

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(cmdText, connection))
            {
                command.CommandType = cmdType;
                command.CommandTimeout = timeout;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                SqlTransaction transaction = null;

                try
                {
                    connection.Open();

                    if (requiresTransaction)
                    {
                        transaction = connection.BeginTransaction();
                        command.Transaction = transaction;
                    }

                    var result = command.ExecuteNonQuery();

                    if (requiresTransaction)
                        transaction.Commit();

                    return result;
                }
                catch
                {
                    if (requiresTransaction)
                        transaction?.Rollback();

                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }
    }
}