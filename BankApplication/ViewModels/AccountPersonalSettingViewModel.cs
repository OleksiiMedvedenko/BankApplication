using BankApplication.ViewModels.Interface;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModels
{
    public class AccountPersonalSettingViewModel : BindableBase, IAccountPersonalSettingViewModel
    {
        public AccountPersonalSettingViewModel()
        {
        }

        private ObservableCollection<string> _countriesWhereBankIsWork = new ObservableCollection<string> { "Poland", "United Kingdom", "USA", "Ukraine" };
        public ObservableCollection<string> CountriesWhereBankIsWork
        {
            get { return _countriesWhereBankIsWork; }
            set 
            {
                _countriesWhereBankIsWork = value;
                RaisePropertyChanged();
            }
        }

    }
}
