using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using BankApplication.Models.AccountOperationModels.OperationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class WithdrawAmmountFromAccount : IOperation
    {
        public int WithdrawAmmountFromAccountID { get; private set; }
        public OperationType OperationType { get; set; }
        public virtual Account Account { get; private set; }
        public decimal Amount { get; private set; }
        public string OperationCode { get; private set; }
        public DateTime WithdrawOperationDate { get; private set; }
        public OperationResult operationResult { get; set; }
        public string CardNumber { get; private set; }

        /// <summary>
        /// For Create operation
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public WithdrawAmmountFromAccount(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
            WithdrawOperationDate = DateTime.Now;
        }

        public void WithdrawAmountExecution(string cardNumber)
        {
            Account.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{cardNumber}").AmountOfMoney -= Amount;
        }

        public override string ToString()
        {
            return "Withdrawing";
        }
    }
}
