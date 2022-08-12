using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Repository
{
    public abstract class DatabaseBase
    {
        protected readonly string connectionString;
        protected readonly SqlConnection connection;

        protected DatabaseBase() //using only in versionApp with default connectionString
        {
            string connectionString = "Server = 10.60.8.48; Database = VersionApp; User Id = verApp_160202V1; Password = dacpExc6MHU7SA9J; Connection Timeout = 300; Asynchronous Processing = True; ";
            connection = new SqlConnection(connectionString);
        }

        protected DatabaseBase(string connectionStringKey) // via configuration file
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ToString();
            connection = new SqlConnection(connectionString);
        }

        protected DatabaseBase(string connectionStringKey, string user, string password, string database)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder["Server"] = VersionApp.VersionApp.Instance().GetDbIp(connectionStringKey);
            sqlConnectionStringBuilder["Database"] = database;
            sqlConnectionStringBuilder["User Id"] = user;
            sqlConnectionStringBuilder["Password"] = password;
            sqlConnectionStringBuilder["Connect Timeout"] = 300;
            sqlConnectionStringBuilder["Trusted_Connection"] = true;
            sqlConnectionStringBuilder["Integrated Security"] = false;
            sqlConnectionStringBuilder["Asynchronous Processing"] = true;

            connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        protected SqlCommand CreateCommand(string command, bool isProcedure = false)
        {
            var output = new SqlCommand(command, connection);

            if (isProcedure)
            {
                output.CommandType = CommandType.StoredProcedure;
            }

            return output;
        }
    }
}
