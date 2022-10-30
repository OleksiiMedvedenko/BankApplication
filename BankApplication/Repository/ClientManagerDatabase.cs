using BankApplication.Models.PersonModel;
using BankApplication.Repository.DatabaseContext;
using BankApplication.Repository.Interfaces;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class ClientManagerDatabase : IClientManagerDatabase
    {
        public DatabaseQueryResult<Client> GetClient(string parameter)
        {
            Client client = null;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    client = database.Clients.SingleOrDefault(x => x.PhoneNumber == parameter || x.Email == parameter);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<Client>(client, ex.Message, ex);
            }

            return new DatabaseQueryResult<Client>(client);
        }

        public DatabaseQueryResult<ObservableCollection<Client>> GetActiveClients()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    clients = (ObservableCollection<Client>)database.Clients.Where(x => x.IsActive == true);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<ObservableCollection<Client>>(clients, ex.Message, ex);
            }
            return new DatabaseQueryResult<ObservableCollection<Client>>(clients);
        }

        public DatabaseQueryResult<bool> SaveNewClientIntoDB(Client client)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    database.Clients.Add(client);
                    commandResult = true;
                    database.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<bool>(commandResult, ex.Message, ex);
            }

            return new DatabaseQueryResult<bool>(commandResult);
        }

        public DatabaseQueryResult<bool> UpdateClientPersonalInformation(Client client)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    var updateClient = database.Clients.SingleOrDefault(x => x.PassportNumber == client.PassportNumber);

                    updateClient = client;
                    commandResult = true;
                    database.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<bool>(commandResult, ex.Message, ex);
            }

            return new DatabaseQueryResult<bool>(commandResult);
        }
    }
}
