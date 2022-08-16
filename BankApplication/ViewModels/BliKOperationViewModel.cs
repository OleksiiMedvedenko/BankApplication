using BankApplication.ViewModels.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace BankApplication.ViewModels
{
    public class BliKOperationViewModel : BindableBase, IBliKOperationViewModel
    {
        public ICommand GetBliKCodeButtonClickCommand { get; set; }

        public BliKOperationViewModel()
        {
            GetBliKCodeButtonClickCommand = new DelegateCommand(GetBliKCodeButton);

            BlikCircleVisibility = false;
            GetBlikCodeButtonEnabled = true;
        }

        private bool _getBlikCodeButtonEnabled;
        public bool GetBlikCodeButtonEnabled
        {
            get { return _getBlikCodeButtonEnabled; }
            set
            {
                _getBlikCodeButtonEnabled = value;
                RaisePropertyChanged();
            }
        }


        private bool _blikCircleVisibility;
        public bool BlikCircleVisibility
        {
            get { return _blikCircleVisibility; }
            set
            {
                _blikCircleVisibility = value;
                RaisePropertyChanged();
            }
        }


        private string _animationOFCircleForBliKView;
        public string AnimationOFCircleForBliKView
        {
            get { return _animationOFCircleForBliKView; }
            set
            {
                _animationOFCircleForBliKView = value;
                RaisePropertyChanged();
            }
        }


        private void GetBliKCodeButton()
        {
            BlikCircleVisibility = true;
            GetBlikCodeButtonEnabled = false;
            Countdown(15, TimeSpan.FromSeconds(1), cur => AnimationOFCircleForBliKView = cur.ToString());
        }


        void Countdown(int count, TimeSpan interval, Action<int> ts)
        {
            var dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = interval;
            dt.Tick += (_, a) =>
            {
                if (count++ == 100)
                {
                    BlikCircleVisibility = false;
                    GetBlikCodeButtonEnabled = true;
                    dt.Stop();
                }
                else
                    ts(count);
            };
            ts(count);
            dt.Start();
        }
    }
}
