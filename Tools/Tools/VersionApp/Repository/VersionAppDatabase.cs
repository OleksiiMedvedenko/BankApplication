using PrehPL.Tools.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.VersionApp.Repository
{
    public class VersionAppDatabase : DatabaseBase
    {

        public VersionAppDatabase() : base()
        {

        }

        public Dictionary<string, string> GetIps()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var procedure = @"SELECT [Id]
                                  ,[Name]
                                  ,[IP]
                                  ,[Description]
                                  ,[Type]
                              FROM [VersionApp].[dbo].[Dbases]
                              WHERE [Type] = 'M'";

            var command = CreateCommand(procedure, false);

            try
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetFieldValue<string>(1);
                        var ip = reader.GetFieldValue<string>(2);
                        result.Add(name, ip);
                    }
                }
                
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
