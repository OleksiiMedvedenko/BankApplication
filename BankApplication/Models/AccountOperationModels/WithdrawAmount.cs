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
    public class WithdrawAmount : IOperation
    {
        public int WithdrawAmmountFromAccountID { get; private set; }
        public OperationType OperationType { get; set; }
        public virtual Account Account { get; private set; }
        public decimal OperationAmount { get; set; }
        public string OperationCode { get; set; }
        public DateTime WithdrawOperationDate { get; private set; }
        public ResultStatus OperationResultStatus { get; set; }
        public string CardNumber { get; private set; }

        /// <summary>
        /// For Create operation
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public WithdrawAmount(Account account, decimal amount)
        {
            Account = account;
            OperationAmount = amount;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
            WithdrawOperationDate = DateTime.Now;

            OperationResultStatus = ResultStatus.Lesion;
        }

        public void WithdrawAmountExecution(string cardNumber)
        {
            Account.Client.Cards.SingleOrDefault(x => x.CardNumber == $"{cardNumber}").AmountOfMoney -= OperationAmount;
        }

        public override string ToString()
        {
            return "Withdrawing";
        }
    }
}
