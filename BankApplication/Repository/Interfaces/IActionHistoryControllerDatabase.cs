using BankApplication.Models.AccountModel;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.AccountOperationModels.OperationResultStatus;
using BankApplication.Models.AccountOperationModels.OperationTypes;
using BankApplication.Models.ActionRecordsHistoryModel;
using DatabaseTools.DatabaseProviderController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository.Interfaces
{
    public interface IActionHistoryControllerDatabase
    {
        DatabaseQueryResult<bool> SaveActionIntoDatabase(IOperation operation, string operationDesciption, Account account, string operatiomTitle = null);

        /// <summary>
        /// [search by Operation Code, Tittle, Date]
        /// </summary>
        DatabaseQueryResult<ObservableCollection<ActionHistory<IOperation>>> GetActionByParameter<T>(T parameter); // observable collection - couse, if search by time = many records 

        DatabaseQueryResult<ObservableCollection<ActionHistory<IOperation>>> GetActionsByTimePeriod(DateTime fromDate, DateTime ToDate);
        DatabaseQueryResult<ObservableCollection<ActionHistory<IOperation>>> GetActionsOfThisTypeOperation(OperationType operationType);
        DatabaseQueryResult<ObservableCollection<ActionHistory<IOperation>>> GetActionsOfThisOperationResultStatus(ResultStatus operationType);
        DatabaseQueryResult<ObservableCollection<ActionHistory<IOperation>>> GetAllActionsOfAccout();
    }
}
