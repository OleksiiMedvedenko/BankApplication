using DatabaseTools.DatabaseProviderController;
using SupportChatApplication.Models;
using SupportChatApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.Repository
{
    public class ChatManagerDatabase : IChatManagerDatabase
    {
        public DatabaseQueryResult<ObservableCollection<MessageModel>> GetChat()
        {
            throw new NotImplementedException();
        }

        public DatabaseQueryResult<ObservableCollection<MessageModel>> GetChat(string contactUserId)
        {
            throw new NotImplementedException();
        }
    }
}
