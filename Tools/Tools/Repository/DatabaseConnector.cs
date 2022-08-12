using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrehPL.Tools.Repository
{
    public class DatabaseConnector : IDatabaseConnector
    {
        private static Dictionary<string, SqlConnection> connections = new Dictionary<string, SqlConnection>();

        public void AddConnection(string connectionName, SqlConnection sqlConnection)
        {
            connections.Add(connectionName, sqlConnection);
        }

        public SqlConnection GetConnection(string connectionName)
        {
            return connections[connectionName];
        }
    }
}
