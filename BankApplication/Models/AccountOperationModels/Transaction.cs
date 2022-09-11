using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using BankApplication.Models.AccountOperationModels.OperationTypes;
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
        public OperationType OperationType { get; set; }
        public Account FromAccount { get; private set; }
        public Account ToAccount { get; private set; }
        public decimal OperationAmount { get; set; }
        public string OperationCode { get; set; }
        public DateTime TransactionOperationDate { get; private set; }
        public ResultStatus OperationResultStatus { get; set; }
        public string CardNumber { get; private set; }

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
            OperationAmount = transactionAmount;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
            TransactionOperationDate = DateTime.Now;

            OperationResultStatus = ResultStatus.TransactionStatus;
        }

        public void TransactionExecution(string fromCardNumber, string toCardNumber)
        {
            FromAccount.Client.Cards.SingleOrDefault(x=> x.CardNumber == $"{fromCardNumber}").AmountOfMoney -= OperationAmount;
            ToAccount.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{toCardNumber}").AmountOfMoney += OperationAmount;
        }

        public override string ToString()
        {
            return "Transaction";
        }
    }
}
