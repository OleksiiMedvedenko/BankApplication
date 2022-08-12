using System.Data.SqlClient;

namespace PrehPL.Tools.Repository
{
    public interface IDatabaseConnector
    {
        SqlConnection GetConnection(string connectionName);
        void AddConnection(string connectionName, SqlConnection sqlConnection);
    }
}
