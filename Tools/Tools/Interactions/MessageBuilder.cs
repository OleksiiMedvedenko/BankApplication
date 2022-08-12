using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Interactions
{
    public static class MessageBuilder
    {
        public static string ErrorMessage(Exception e, int tabs = 0)
        {
            if (e is null) { return "Brak wyjątku."; }

            var tab = new string(' ', tabs);
            var builder = new StringBuilder();

            builder.AppendLine($"{tab}Exception:     {e.GetType().Name}");
            builder.AppendLine($"{tab}Message:       {e.Message}");
            builder.AppendLine($"{tab}Source:        {e.Source}");
            builder.AppendLine($"{tab}StackTrace:    {e.StackTrace}");

            if (e.InnerException != null)
            {
                builder.AppendLine($"{tab}InnerException:");
                builder.AppendLine(ErrorMessage(e.InnerException, tabs += 4));
            }
            return builder.ToString();
        }
    }
}
