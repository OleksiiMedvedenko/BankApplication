using BankApplication.Models.PersonModel;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.Interfaces
{
    public interface IClientManagerDatabase
    {
        DatabaseQueryResult<bool> SaveNewClientIntoDB(Client client);
        DatabaseQueryResult<bool> UpdateClientPersonalInformation(Client client);

        /// <summary>
        /// By Phone number or Email
        /// </summary>
        /// <returns></returns>
        DatabaseQueryResult<Client> GetClient(string parameter);

        DatabaseQueryResult<ObservableCollection<Client>> GetActiveClients(); // couse check on UNIQUE value
    }
}
