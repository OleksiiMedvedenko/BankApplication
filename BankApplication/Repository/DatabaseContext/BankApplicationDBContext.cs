using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.ActionRecordsHistoryModel;
using BankApplication.Models.CardsModel;
using BankApplication.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.DatabaseContext
{
    public class BankApplicationDBContext : DbContext
    {
        public BankApplicationDBContext() : base("BankApplicationDBContext")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AddingAmount> AddingAmountToAccounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<WithdrawAmount> WithdrawAmmountFromAccounts { get; set; }

        public DbSet<ActionHistory<IOperation>> ActionHistory { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
