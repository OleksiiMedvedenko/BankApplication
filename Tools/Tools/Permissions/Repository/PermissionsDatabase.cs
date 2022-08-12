using PrehPL.Tools.Permissions.Model;
using PrehPL.Tools.Permissions.Repository.Interfaces;
using PrehPL.Tools.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Permissions.Repository
{
    public class PermissionsDatabase : DatabaseBase, IPermissionsDatabase
    {
        public PermissionsDatabase(string host, string user, string password, string database) : base(host, user, password, database)
        {

        }

        public async Task<List<Permission>> GetPermissionsAsync(string login) 
        {
            List<Permission> result = new List<Permission>();

            var procedure = @"SELECT P.[idPermission]
                                    ,P.[idGroup]
                                    ,P.[idApplication]
                                    ,A.AppName
                                    ,P.[idModule]
                                    ,AM.[appModuleName]
                                    ,P.[permissionType]
                                    ,P.[permissionStatus]
                                    ,P.[insertedDate]
                                    ,P.[modificationDate]
                                    FROM [DevMes].[dbo].[user.permission] P
                                    INNER JOIN [DevMes].[dbo].[user.userGroup] UG ON UG.idGroup = P.idGroup
                                    INNER JOIN [DevMes].[dbo].[user.user] U ON U.idUser = UG.idUser
                                    INNER JOIN [TotalStarter].[dbo].[Application] A ON A.Id = P.idApplication
                                    LEFT JOIN [TotalStarter].[dbo].[AppModule] AM ON AM.idModule = P.idModule
                                    WHERE U.login = @login";

            var command = CreateCommand(procedure, false);
            command.Parameters.AddWithValue("@login", login);

            try
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Permission permission = new Permission();
                        permission.Id = await reader.GetFieldValueAsync<int>(0);
                        permission.IdGroup = await reader.GetFieldValueAsync<int>(1);
                        permission.IdApplication = await reader.GetFieldValueAsync<int>(2);
                        permission.Application = await reader.GetFieldValueAsync<string>(3);
                        if (!await reader.IsDBNullAsync(4))
                        {
                            permission.IdModule = await reader.GetFieldValueAsync<Int16>(4);
                        }
                        else
                        {
                            permission.IdModule = 0;
                        }
                        permission.Module = !await reader.IsDBNullAsync(5) ? await reader.GetFieldValueAsync<string>(5) : string.Empty;
                        string type = await reader.GetFieldValueAsync<string>(6);
                        if (type == "R")
                        {
                            permission.PermissionType = PermissionsType.ReadOnly;
                        } 
                        else if (type == "W")
                        {
                            permission.PermissionType = PermissionsType.ReadWrite;
                        }
                        permission.PermissionStatus = await reader.GetFieldValueAsync<int>(7);
                        result.Add(permission);
                    }
                }

            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public List<Permission> GetPermissions(string login)
        {
            List<Permission> result = new List<Permission>();

            var procedure = @"SELECT P.[idPermission]
                                    ,P.[idGroup]
                                    ,P.[idApplication]
                                    ,A.AppName
                                    ,P.[idModule]
                                    ,AM.[appModuleName]
                                    ,P.[permissionType]
                                    ,P.[permissionStatus]
                                    ,P.[insertedDate]
                                    ,P.[modificationDate]
                                    FROM [DevMes].[dbo].[user.permission] P
                                    INNER JOIN [DevMes].[dbo].[user.userGroup] UG ON UG.idGroup = P.idGroup
                                    INNER JOIN [DevMes].[dbo].[user.user] U ON U.idUser = UG.idUser
                                    INNER JOIN [TotalStarter].[dbo].[Application] A ON A.Id = P.idApplication
                                    LEFT JOIN [TotalStarter].[dbo].[AppModule] AM ON AM.idModule = P.idModule
                                    WHERE U.login = @login";

            var command = CreateCommand(procedure, false);
            command.Parameters.AddWithValue("@login", login);

            try
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Permission permission = new Permission();
                        permission.Id = reader.GetFieldValue<int>(0);
                        permission.IdGroup = reader.GetFieldValue<int>(1);
                        permission.IdApplication = reader.GetFieldValue<int>(2);
                        permission.Application = reader.GetFieldValue<string>(3);
                        if (!reader.IsDBNull(4))
                        {
                            permission.IdModule = reader.GetFieldValue<Int16>(4);
                        }
                        else
                        {
                            permission.IdModule = 0;
                        }
                        permission.Module = !reader.IsDBNull(5) ? reader.GetFieldValue<string>(5) : string.Empty;
                        string type = reader.GetFieldValue<string>(6);
                        if (type == "R")
                        {
                            permission.PermissionType = PermissionsType.ReadOnly;
                        }
                        else if (type == "W")
                        {
                            permission.PermissionType = PermissionsType.ReadWrite;
                        }
                        permission.PermissionStatus = reader.GetFieldValue<int>(7);
                        result.Add(permission);
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
