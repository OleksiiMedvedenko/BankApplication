using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models.AccountOperationModels
{
    public class Transaction : IOperation
    {
        public int TransactionID { get; private set; }
        public virtual Account FromAccount { get; private set; }
        public Account ToAccount { get; private set; }
        public decimal TransactionAmount { get; private set; }
        public string OperationCode { get; private set; }
        public DateTime TransactionOperationDate { get; private set; }

        /// <summary>
        /// For Create transaction
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="transactionAmount"></param>
        /// <param name="transactionID"></param>
        public Transaction(Account fromAccount, Account toAccount, decimal transactionAmount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransactionAmount = transactionAmount;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
            TransactionOperationDate = DateTime.Now;
        }

        public void TransactionExecution(string fromCardNumber, string toCardNumber)
        {
            FromAccount.Client.Cards.SingleOrDefault(x=> x.CardNumber == $"{fromCardNumber}").AmountOfMoney -= TransactionAmount;
            ToAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{toCardNumber}").AmountOfMoney += TransactionAmount;
        }

        public override string ToString()
        {
            return "Transaction";
        }
    }
}
