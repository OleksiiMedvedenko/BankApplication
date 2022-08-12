using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class AddingAmountToAccount : IOperation
    {
        public int AddingAmountToAccountID { get; private set; }
        public virtual Account Account { get; private set; }
        public decimal Amount { get; private set; }
        public string OperationCode { get; private set; }
        public DateTime AddingOperationDate { get; private set; }

        public AddingAmountToAccount(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
            AddingOperationDate = DateTime.Now;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
        }

        public void AddingAmountExecution(string cardNumber)
        {
            Account.Client.Cards.SingleOrDefault(x=> x.CardNumber == $"{cardNumber}").AmountOfMoney += Amount;
        }

        public override string ToString()
        {
            return "Adding";
        }
    }
}
