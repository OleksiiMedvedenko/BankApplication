using System;

namespace PrehPL.Tools.Repository
{
    public class DatabaseResult<T>
    {
        public string ErrorMsg { get; set; }
        public bool ErrorExists { get; set; }
        public T Result { get; set; }
        public Exception Error { get; private set; }

        public DatabaseResult(T result, string errorMsg = null, Exception e = null)
        {
            Result = result;
            Error = e;
            ErrorMsg = errorMsg;
            ErrorExists =
                (errorMsg == null && e == null)
                ? false //If not null
                : true; //If null
        }
    }

    public class DatabaseResult
    {
        public string ErrorMsg { get; set; }
        public bool ErrorExists { get; set; }
        public Exception Error { get; private set; }

        public DatabaseResult(string errorMsg = null, Exception e = null)
        {
            Error = e;
            ErrorMsg = errorMsg;
            ErrorExists =
                (errorMsg == null && e == null)
                ? false //If not null
                : true; //If null
        }
    }
}
