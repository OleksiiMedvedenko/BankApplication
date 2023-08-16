using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.Models
{
    public class ChatModel
    {
        public int ChatID { get; private set; }
        public int ClientID { get; private set; }
        public int AdminID { get; private set; }
        public int MessageID { get; private set; }
        public string ProblemTitle { get; private set; }
        public ChatStatus StatusOfProblem { get; private set; }
    }
}
