using BankApplication.ViewModels.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApplication.ViewModels
{
    public class DepositViewModel : BindableBase, IDepositViewModel
    {
        public ICommand ChangeMinusDepositTimePeriodMouseClick { get; set; }
        public ICommand ChangeAddDeposiTimePeriodMouseClick { get; set; }
        public ICommand EarlyDissolutionClickToggleButton { get; set; }
        public DepositViewModel()
        {

            ChangeAddDeposiTimePeriodMouseClick = new DelegateCommand(ChangeAddDeposiTimePeriod);
            ChangeMinusDepositTimePeriodMouseClick = new DelegateCommand(ChangeMinusDepositTimePeriod);
            EarlyDissolutionClickToggleButton = new DelegateCommand(UpdateInformationAboutInterestRateInUI);

            IsEnableMinusButton = true;
            IsEnableAddButton = true;
            IsEnableEarlyDissolutionButton = true;
        }

        private bool _statusEarlyDissolutionToggleButton;

        public bool StatusEarlyDissolutionToggleButton
        {
            get { return _statusEarlyDissolutionToggleButton; }
            set 
            { 
                _statusEarlyDissolutionToggleButton = value;
                RaisePropertyChanged();
            }
        }


        private int _depositeTimePeriod = 12;
        public int DepositeTimePeriod
        {
            get { return _depositeTimePeriod; }
            set 
            { 
                _depositeTimePeriod = value;
                RaisePropertyChanged();
            }
        }

        private float _depositRate = 7;
        public float DepositRate
        {
            get { return _depositRate; }
            set 
            { 
                _depositRate = value;
                RaisePropertyChanged();
            }
        }

        private bool _isEnableMinusButton;
        public bool IsEnableMinusButton
        {
            get { return _isEnableMinusButton; }
            set 
            { 
                _isEnableMinusButton = value;
                RaisePropertyChanged();
            }
        }

        private bool _isEnableAddButton;
        public bool IsEnableAddButton
        {
            get { return _isEnableAddButton; }
            set 
            { 
                _isEnableAddButton = value;
                RaisePropertyChanged();
            }
        }

        private bool _isEnableEarlyDissolutionButton;
        public bool IsEnableEarlyDissolutionButton
        {
            get { return _isEnableEarlyDissolutionButton; }
            set 
            { 
                _isEnableEarlyDissolutionButton = value;
                RaisePropertyChanged();
            }
        }



        private void ChangeMinusDepositTimePeriod()
        {
            IsEnableAddButton = true;

            if (DepositeTimePeriod == 2)
            {
                IsEnableMinusButton = false;
            }

            if (DepositeTimePeriod > 1)
            {

                if (DepositeTimePeriod <= 12)
                {
                    DepositeTimePeriod -= 1;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }

                if (DepositeTimePeriod >= 13 && DepositeTimePeriod <= 18)
                {
                    DepositeTimePeriod -= 3;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }

                if (DepositeTimePeriod >= 18)
                {
                    DepositeTimePeriod -= 6;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }
            }
        }

        private void ChangeAddDeposiTimePeriod()
        {
            IsEnableMinusButton = true;

            if (DepositeTimePeriod == 18)
            {
                IsEnableAddButton = false;
            }

            if (DepositeTimePeriod < 24)
            {
                if (DepositeTimePeriod < 12)
                {
                    DepositeTimePeriod += 1;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }

                if (DepositeTimePeriod >= 12 && DepositeTimePeriod < 18)
                {
                    DepositeTimePeriod += 3;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }

                if (DepositeTimePeriod >= 18)
                {
                    DepositeTimePeriod += 6;
                    CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
                    return;
                }
            }
        }

        private float SetDepositInterestRateByDepositTime(int depositTimeInMonths)
        {
            switch (depositTimeInMonths)
            {
                case 1:
                    return DepositRate = 2;
                case 2:
                    return DepositRate = 2;
                case 3:
                    return DepositRate = 4.5f;
                case 4:
                    return DepositRate = 4.5f;
                case 5:
                    return DepositRate = 4.5f;
                case 6:
                    return DepositRate = 6f;
                case 7:
                    return DepositRate = 6f;
                case 8:
                    return DepositRate = 6f;
                case 9:
                    return DepositRate = 6.5f;
                case 10:
                    return DepositRate = 6.5f;
                case 11:
                    return DepositRate = 6.5f;
                case 12:
                    return DepositRate = 7f;
                case 15:
                    return DepositRate = 8f;
                case 18:
                    return DepositRate = 8f;
                case 24:
                    return DepositRate = 8f;
                default:
                    return DepositRate;
            }
        }
        private void CheckOnEarlyDissolutionOrSetDefaultValue(int depositeTimePeriod) // month 3 - 12 
        {
            EnableDissenableEarlyDissuluttionDepositToggleButtun(depositeTimePeriod);

            if (StatusEarlyDissolutionToggleButton == true)
            {
                if (depositeTimePeriod >= 3 && depositeTimePeriod <= 12)
                {
                    DepositRate = 0.5f;
                }
                else
                {
                    SetDepositInterestRateByDepositTime(depositeTimePeriod);
                }
            }
            else if(StatusEarlyDissolutionToggleButton == false)
            {
                SetDepositInterestRateByDepositTime(depositeTimePeriod);
            }
        }
        private void UpdateInformationAboutInterestRateInUI()
        {
            CheckOnEarlyDissolutionOrSetDefaultValue(DepositeTimePeriod);
        }
        private void EnableDissenableEarlyDissuluttionDepositToggleButtun(int depositeTImePeriod)
        {
            if (depositeTImePeriod > 2 && depositeTImePeriod < 13)
            {
                IsEnableEarlyDissolutionButton = true;
            }
            else if (depositeTImePeriod <= 2 || depositeTImePeriod >= 13)
            {
                IsEnableEarlyDissolutionButton = false;
                StatusEarlyDissolutionToggleButton = false;
            }
        }
    }
}
