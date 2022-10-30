using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Image { get; set; }
        public TypeOfUser TypeOfUser { get; set; }

        public ObservableCollection<MessageModel> Messages { get; set; }

        public string LastMessage => Messages.Last().Message;
    }
}
