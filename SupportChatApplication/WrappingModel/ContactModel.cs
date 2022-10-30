using SupportChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.WrappingModel
{
    public class ContactModel
    {
        public string Username { get; set; }
        public byte[] Image { get; set; }
        public TypeOfUser TypeOfUser { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

        public string LastMessage => Messages.Last().MessageString;

        public ContactModel()
        {

        }
    }
}
