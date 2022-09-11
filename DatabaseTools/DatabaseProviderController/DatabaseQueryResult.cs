using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools.DatabaseProviderController
{
    public class DatabaseQueryResult<T>
    {
        public string ErrorMessage { get; set; }
        public bool ErrorExists { get; set; }
        public T QueryResult { get; set; }
        public Exception Error { get; private set; }

        public DatabaseQueryResult(T result, string errorMsg = null, Exception e = null)
        {
            QueryResult = result;
            Error = e;
            ErrorMessage = errorMsg;
            ErrorExists =
                (errorMsg == null && e == null)
                ? false //If not null
                : true; //If null
        }
    }

    public class DatabaseQueryResult
    {
        public string ErrorMessage { get; set; }
        public bool ErrorExists { get; set; }
        public Exception Error { get; private set; }

        public DatabaseQueryResult(string errorMsg = null, Exception e = null)
        {
            Error = e;
            ErrorMessage = errorMsg;
            ErrorExists =
                (errorMsg == null && e == null)
                ? false //If not null
                : true; //If null
        }
    }
}
