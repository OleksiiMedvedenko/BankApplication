using DatabaseTools.DatabaseProviderController;
using SupportChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChatApplication.Repository.Interface
{
    public interface IChatManagerDatabase
    {
        DatabaseQueryResult<ObservableCollection<MessageModel>> GetChat(string contactUserId);

    }
}
