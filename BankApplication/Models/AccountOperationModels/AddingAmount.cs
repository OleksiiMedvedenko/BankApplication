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
    public class AddingAmount : IOperation
    {
        public int AddingAmountToAccountID { get; private set; }
        public OperationType OperationType { get; set; } // set id in DB 
        public virtual Account Account { get; private set; }
        public decimal OperationAmount { get; set; }
        public string OperationCode { get; set; }
        public DateTime AddingOperationDate { get; private set; }
        public ResultStatus OperationResultStatus { get; set; }
        public string CardNumber { get; private set; }


        /// <summary>
        /// For Save In DB
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public AddingAmount(Account account, decimal amount)
        {
            Account = account;
            OperationAmount = amount;
            AddingOperationDate = DateTime.Now;
            OperationCode = Guid.NewGuid().ToString().Substring(0, 12);
            OperationResultStatus = ResultStatus.Income;
        }

        /// <summary>
        /// For get from DB
        /// </summary>


        public void AddingAmountExecution(string cardNumber)
        {
            Account.Client.Cards.SingleOrDefault(x=> x.CardNumber == $"{cardNumber}").AmountOfMoney += OperationAmount;
        }

        public override string ToString()
        {
            return "Adding";
        }
    }
}
