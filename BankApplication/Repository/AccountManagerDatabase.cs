using BankApplication.Models.AccountModel;
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
    public class AccountManagerDatabase : IAccountManagerDatabase
    {
        public DatabaseQueryResult<bool> DeactivateAccount(Account account)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    var deactivateAccount = database.Accounts.SingleOrDefault(x => x.AccountCode == account.AccountCode);

                    deactivateAccount.IsActive = false;
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

        public DatabaseQueryResult<Account> GetAccount(string login, string password)
        {
            Account account = null;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    account = database.Accounts.SingleOrDefault(x => x.Login == login && x.Password == password);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<Account>(account, ex.Message, ex);
            }

            return new DatabaseQueryResult<Account>(account);
        }

        public DatabaseQueryResult<ObservableCollection<Account>> GetActiveAccounts()
        {
            ObservableCollection<Account> accounts = new ObservableCollection<Account>();

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    accounts = (ObservableCollection<Account>)database.Accounts.Where(x => x.IsActive == true);
                }
            }
            catch (Exception ex)
            {
                return new DatabaseQueryResult<ObservableCollection<Account>>(accounts, ex.Message, ex);
            }
            return new DatabaseQueryResult<ObservableCollection<Account>>(accounts);
        }

        public DatabaseQueryResult<bool> SaveNewAccountIntoDatabase(Account account)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    database.Accounts.Add(account);
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
    

        public DatabaseQueryResult<bool> UpdateAccountPersonalSettings(Account account)
        {
            bool commandResult = false;

            try
            {
                using (var database = new BankApplicationDBContext())
                {
                    var updateAccount = database.Accounts.SingleOrDefault(x => x.AccountCode == account.AccountCode);

                    updateAccount = account;
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
