using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class WithdrawAmmountFromAccount : IOperation
    {
        public Account Account { get; private set; }
        public decimal Amount { get; private set; }
        public Guid OperationID { get; private set; }
        public DateTime WithdrawOperationDate { get; private set; }

        public WithdrawAmmountFromAccount(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
            OperationID = new Guid();
            WithdrawOperationDate = DateTime.Now;
        }

        public void WithdrawAmountExecution(string cardNumber)
        {
            Account.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{cardNumber}").AmountOfMoney -= Amount;
        }
    }
}
