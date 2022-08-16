using BankApplication.Models.AccountOperationModels;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.ActionRecordsHistoryModel;
using BankApplication.Models.PersonModel;
using BankApplication.ViewModels.Interface;
using PrehPL.Tools.Extensions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModels
{
    public class ActionHistoryViewModel : BindableBase, IActionHistoryViewModel
    {
        public ActionHistoryViewModel()
        {
            //var client = new Client(1, "test", "test", "test@gmail.com", "123456", "FZ123", new byte[3]);
            //var account = new Models.AccountModel.Account(1, "test", "test", client);
            //var operation = new AddingAmountToAccount(account, 200);
            //var operation2 = new WithdrawAmmountFromAccount(account, 100);

            //ListOfCardOperationHistory = new ObservableCollectionPropertyNotify<ActionHistory>
            //{
            //    new ActionHistory(operation, "Test description", account, operation.Amount, OperationResult.Income, operation.OperationCode),
            //    new ActionHistory(operation2, "Test description2", account, operation2.Amount, OperationResult.Lesion, operation.OperationCode),
            //};
        }

        private ObservableCollectionPropertyNotify<ActionHistory<IOperation>> _istOfCardOperationHistory;
        public ObservableCollectionPropertyNotify<ActionHistory<IOperation>> ListOfCardOperationHistory
        {
            get { return _istOfCardOperationHistory; }
            set { _istOfCardOperationHistory = value; }
        }
    }
}
