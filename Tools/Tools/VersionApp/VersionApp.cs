using PrehPL.Tools.VersionApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.VersionApp
{
    public class VersionApp
    {
        private VersionAppDatabase _repo;
        private static Dictionary<string, string> _ips;
        private static VersionApp _instance;

        private VersionApp()
        {

        }

        public static VersionApp Instance()
        {
            if (_instance == null)
            {
                _instance = new VersionApp();
            }
            return _instance;
        }

        public void Init()
        {
            if (_repo == null)
            {
                _repo = new VersionAppDatabase();
            }
            _ips = _repo.GetIps();
        }

        public string GetDbIp(string serverName)
        {
            if (!_ips.TryGetValue(serverName, out string resultIp))
            {
                resultIp = "brak hosta";
            }

            return resultIp;
        }
    }
}
