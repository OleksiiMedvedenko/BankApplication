using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Permissions.Model
{
    public enum PermissionsType
    {
        ReadOnly,
        ReadWrite,
        NoPermissions
    }

    public class Permission
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public int IdApplication { get; set; }
        public Int16 IdModule { get; set; }
        public string Module { get; set; }
        public string Application { get; set; }
        public PermissionsType PermissionType { get; set; } //r - readonly, w- readwrite
        public int PermissionStatus { get; set; } //37 enabled, 38 disabled

        public Permission()
        {
            Id = 0;
            IdApplication = 0;
            IdGroup = 0;
            IdModule = 0;
            PermissionStatus = 38;
            PermissionType = PermissionsType.NoPermissions;
        }
    }
}
