using BankApplication.ViewModels.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApplication.ViewModels
{
    public class BliKOperationViewModel : BindableBase, IBliKOperationViewModel
    {
        private bool IsActiveButton { get; set; } = false;

        public ICommand StartStopBliKCodeButtonClickCommand { get; set; }
        public BliKOperationViewModel()
        {
            StartStopBliKCodeButtonClickCommand = new DelegateCommand(StartStopGetBliKCode);
        }



        private void StartStopGetBliKCode()
        {

        }
    }
}
