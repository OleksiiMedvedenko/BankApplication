using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BankApplication.Models.ActionRecordsHistoryModel
{
    public class ActionHistory<T> : BindableBase 
                                  where T : IOperation
    {
        public int ActionHistoryID { get; private set; }
        public int OperationID { get; private set; }

        public virtual Account Account { get; private set; }
        public string OperationDescription { get; private set; }
        public string OperationTitle { get; private set; }
        public DateTime ActionDate { get; private set; }
      
        [NotMapped] // cose it`s for Create 
        public T Operation { get; private set; }

        /// <summary>
        /// For Save action in DB
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account) // get operation code from operation class
        {
            Operation = operation;
            OperationTitle = operation.ToString();
            OperationDescription = operationDesciption;
            Account = account;
            ActionDate = DateTime.Now;
        }

        /// <summary>
        /// For GEt action From db
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationDesciption"></param>
        /// <param name="account"></param>
        /// <param name="actionDate"></param>
        public ActionHistory(T operation, string operationDesciption, Account account, DateTime actionDate)
        {
            OperationTitle = operation.ToString();
            Operation = operation;
            OperationDescription = operationDesciption;
            Account = account;
            ActionDate = actionDate;
        }
    }
}
