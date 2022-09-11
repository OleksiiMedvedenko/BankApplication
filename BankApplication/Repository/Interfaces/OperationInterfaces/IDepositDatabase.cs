using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels;
using BankApplication.Models.CardsModel;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.Interfaces.OperationInterfaces
{
    public interface IDepositDatabase
    {
        DatabaseQueryResult<bool> ExequteDepositOperation(Account account, Card card, Deposit deposit);
    }
}
