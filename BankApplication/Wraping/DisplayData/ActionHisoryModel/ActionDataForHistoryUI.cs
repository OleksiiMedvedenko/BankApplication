using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using BankApplication.Models.ActionRecordsHistoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Wraping.DisplayData.ActionHisoryModel
{
    public class ActionDataForHistoryUI
    {
        public string OperationCode { get; private set; }
        public string OperationTitle { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime DateOfOperation { get; private set; }
        public ResultStatus Status { get; private set; }

        public ActionDataForHistoryUI(IOperation operation, ActionHistory<IOperation> history)
        {
            OperationCode = operation.OperationCode;
            OperationTitle = history.OperationTitle;
            Amount = operation.OperationAmount;
            Description = history.OperationDescription;
            DateOfOperation = history.ActionDate;
            Status = operation.OperationResultStatus;
        }
    }
}
