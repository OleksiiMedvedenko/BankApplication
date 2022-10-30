using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.Models
{
    public class Message
    {
        public int MessageID { get; private set; }
        public string MessageString { get; private set; }
        public DateTime SendingTime { get; private set; }
        public TypeOfUser FromUser { get; private set; }

        public Message(string message, TypeOfUser fromUser)
        {
            MessageString = message;
            FromUser = fromUser;
        }
    }
}
