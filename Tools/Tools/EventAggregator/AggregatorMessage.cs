using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.EventAggregator
{
    public class AggregatorMessage<T>
    {
        public AggregatorMessage(T value, string command = null)
        {
            Value = value;
            Command = command;
        }

        public T Value { get; set; }
        public string Command { get; set; }
    }
}
