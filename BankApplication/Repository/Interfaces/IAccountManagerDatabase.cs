using BankApplication.Models.AccountModel;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.Interfaces
{
    public interface IAccountManagerDatabase
    {
        DatabaseQueryResult<bool> SaveNewAccountIntoDatabase(Account account);
        DatabaseQueryResult<bool> UpdateAccountPersonalSettings(Account account);
        DatabaseQueryResult<bool> DeactivateAccount(Account account);

        DatabaseQueryResult<Account> GetAccount(string login, string password);
        DatabaseQueryResult<ObservableCollection<Account>> GetAccounts();
    }
}
