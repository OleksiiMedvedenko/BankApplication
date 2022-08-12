using PrehPL.Tools.Permissions.Interfaces;
using PrehPL.Tools.Permissions.Model;
using PrehPL.Tools.Permissions.Repository;
using PrehPL.Tools.Permissions.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Permissions
{
    public class PermissionsProvider : IPermissionsProvider
    {
        private IPermissionsDatabase _permissionDatabase;

        public PermissionsProvider(string host, string user, string password, string database, IPermissionsDatabase permissionDatabase = null)
        {
            if (permissionDatabase == null)
            {
                _permissionDatabase = new PermissionsDatabase(host, user, password, database);
            } 
            else
            {
                _permissionDatabase = permissionDatabase;
            }
        }

        public void SetDatabase(IPermissionsDatabase permissionsDatabase)
        {
            _permissionDatabase = permissionsDatabase;
        }

        public List<Permission> GetPermissions(string login)
        {
            return _permissionDatabase.GetPermissions(login);
        }

        public List<Permission> GetPermissions(string login, string applicationName, string moduleName)
        {
            List<Permission> result = new List<Permission>();
            List<Permission> permissions = GetPermissions(login);
            if (permissions.Count == 0)
            {
                return permissions;
            }
            foreach (Permission permission in permissions)
            {
                if (moduleName != "")
                {
                    if (permission.Application == applicationName && permission.Module == moduleName && permission.PermissionStatus == 37)
                    {
                        result.Add(permission);
                        break;
                    }
                }
                else
                {
                    if (permission.Application == applicationName && permission.PermissionStatus == 37)
                    {
                        result.Add(permission);
                        break;
                    }
                }
            }
            return result;
        }

        public async Task<List<Permission>> GetPermissionsAsync(string login)
        {
            return await _permissionDatabase.GetPermissionsAsync(login);
        }

        public async Task<List<Permission>> GetPermissionsAsync(string login, string applicationName, string moduleName)
        {
            List<Permission> result = new List<Permission>();
            List<Permission> permissions = await GetPermissionsAsync(login);
            if (permissions.Count == 0)
            {
                return permissions;
            }
            foreach (Permission permission in permissions)
            {
                if (moduleName != "")
                {
                    if (permission.Application == applicationName && permission.Module == moduleName && permission.PermissionStatus == 37)
                    {
                        result.Add(permission);
                    }
                }
                else
                {
                    if (permission.Application == applicationName && permission.PermissionStatus == 37)
                    {
                        result.Add(permission);
                    }
                }
            }
            return result;
        }
    }
}
