using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultInAmount;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BankApplication.Models.ActionRecordsHistoryModel
{
    public class ActionHistory<T> : BindableBase
                                    where T : IOperation  
    {
        public virtual IOperation OperationID { get; private set; }
        public virtual Account Account { get; private set; }

        public T Operation { get; private set; }
        public string OperationCode { get; private set; }
        public string NameOfOperation { get; private set; }
        public string OperationDescription { get; private set; }
        public DateTime ActionDate { get; private set; }
        public decimal AmountOfMoneyAction { get; private set; }
        public OperationResult OperationResult { get; private set; }

        /// <summary>
        /// For Save action in DB
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account, decimal amountOfMoneyAction, OperationResult operationResult, string operationCode) // get operation code from operation class
        {
            Operation = operation;
            NameOfOperation = operation.ToString();
            OperationDescription = operationDesciption;
            Account = account;
            AmountOfMoneyAction = amountOfMoneyAction;
            ActionDate = DateTime.Now;
            OperationCode = operationCode;
            OperationResult = operationResult;
        }

        /// <summary>
        /// For GEt action From db
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account, DateTime actionDate, decimal amountOfMoneyAction, string operationCode, OperationResult operationResult)
        {
            NameOfOperation = operation.ToString();
            Operation = operation;
            OperationDescription = operationDesciption;
            Account = account;
            ActionDate = actionDate;
            AmountOfMoneyAction = amountOfMoneyAction;
            OperationCode = operationCode;
            OperationResult = operationResult;
        }
    }
}
