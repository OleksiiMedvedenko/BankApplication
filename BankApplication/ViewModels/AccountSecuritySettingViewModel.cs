using BankApplication.ViewModels.Interface;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.ViewModels
{
    public class AccountSecuritySettingViewModel : BindableBase, IAccountSecuritySettingViewModel
    {
        public AccountSecuritySettingViewModel()
        {

        }

        private int _cardPINCodeTextBox = 1234;
        public int CardPINCodeTextBox
        {
            get { return _cardPINCodeTextBox; }
            set 
            { 
                _cardPINCodeTextBox = value;
                RaisePropertyChanged();
            }
        }

    }
}
