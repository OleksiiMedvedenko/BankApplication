using PrehPL.Tools.Permissions.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Permissions.Interfaces
{
    public interface IPermissionsProvider
    {
        List<Permission> GetPermissions(string login);
        List<Permission> GetPermissions(string login, string applicationName, string moduleName);
        Task<List<Permission>> GetPermissionsAsync(string login);
        Task<List<Permission>> GetPermissionsAsync(string login, string applicationName, string moduleName);
    }
}
