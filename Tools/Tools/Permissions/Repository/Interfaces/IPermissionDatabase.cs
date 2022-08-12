using PrehPL.Tools.Permissions.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Permissions.Repository.Interfaces
{
    public interface IPermissionsDatabase
    {
        Task<List<Permission>> GetPermissionsAsync(string login);
        List<Permission> GetPermissions(string login);
    }
}
