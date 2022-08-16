using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels.OperationTypes
{
    public enum OperationType
    {
        AddingAmountToAccount,
        Deposit,
        Transaction,
        WithdrawAmmountFromAccount
    }
}
