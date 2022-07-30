using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using System;

namespace BankApplication.Models.ActionRecordsHistoryModel
{
    public class ActionHistory<T> where T : IOperation
    {
        public int OperationID { get; private set; }
        public T Operation { get; private set; }
        public string OperationDescription { get; private set; }
        public Account Account { get; private set; }
        public DateTime ActionDate { get; set; }


        /// <summary>
        /// For Save action in DB
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account)
        {
            Operation = operation;
            OperationDescription = operationDesciption;
            Account = account;
            ActionDate = DateTime.Now;
        }

        /// <summary>
        /// For Create action
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account, DateTime actionDate)
        {
            Operation = operation;
            OperationDescription = operationDesciption;
            Account = account;
            ActionDate = actionDate;
        }
    }
}
