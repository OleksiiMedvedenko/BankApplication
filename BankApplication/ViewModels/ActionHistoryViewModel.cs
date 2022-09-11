using BankApplication.Models.AccountOperationModels;
using BankApplication.Models.AccountOperationModels.Interface;
using BankApplication.Models.ActionRecordsHistoryModel;
using BankApplication.Models.PersonModel;
using BankApplication.ViewModels.Interface;
using PrehPL.Tools.Extensions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var client = new Client(1, "test", "test", "test@gmail.com", "123456", "FZ123", new byte[3]);
            var client2 = new Client(2, "test2", "test2", "test2@gmail.com", "521631", "FZ6231", new byte[3]);
            var account = new Models.AccountModel.Account(1, "test", "test", client);
            var account2 = new Models.AccountModel.Account(2, "test2", "test2", client2);
            var operation = new AddingAmount(account, 200);
            var operation2 = new WithdrawAmount(account, 100);
            var operation3 = new Transaction(account, account2, 10);

            ListOfCardOperationHistory = new ObservableCollectionPropertyNotify<ActionHistory<IOperation>>
            {
                new ActionHistory<IOperation>(operation, "Test description", account),
                new ActionHistory<IOperation>(operation2, "Test description2", account, "Title"),
                new ActionHistory<IOperation>(operation2, "Test description2", account),
                new ActionHistory<IOperation>(operation2, "Test description2", account),
                new ActionHistory<IOperation>(operation3, "Test description2", account),
                new ActionHistory<IOperation>(operation3, "Test description2", account),
            };
        }

        private ObservableCollection<string> _fullActionDescription = new ObservableCollection<string>() { "Some text" };
        public ObservableCollection<string> FullActionDescription
        {
            get { return _fullActionDescription; }
            set 
            {
                _fullActionDescription = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<ActionHistory<IOperation>> _istOfCardOperationHistory;
        public ObservableCollection<ActionHistory<IOperation>> ListOfCardOperationHistory
        {
            get { return _istOfCardOperationHistory; }
            set 
            { 
                _istOfCardOperationHistory = value;
                RaisePropertyChanged();
            }
        }
    }
}
