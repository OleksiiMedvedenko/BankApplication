using BankApplication.ViewModels.Interface;
using BankApplication.Views;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApplication.ViewModels
{
    public class AccountViewModel : BindableBase, IAccountViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;
        private readonly IEventAggregator _eventAggregator;

        public ICommand OpenAccountPersonalSettingViewButtonClick { get; set; }
        public ICommand OpenAccountSecuritySettingViewButtonClick { get; set; }
        public ICommand OpenAccountStatisticsViewButtonClick { get; set; }

        public AccountViewModel(IRegionManager regionManager, IContainerExtension containerExtension, IEventAggregator eventAggregator)
        {
            OpenAccountPersonalSettingViewButtonClick = new DelegateCommand(OpenAccountPersonalSettinView);
            OpenAccountSecuritySettingViewButtonClick = new DelegateCommand(OpenAccountSecuritySettinView);
            OpenAccountStatisticsViewButtonClick = new DelegateCommand(OpenAccountStatisticsView);

            _regionManager = regionManager;
            _containerExtension = containerExtension;
            _eventAggregator = eventAggregator;
        }

        private void OpenAccountStatisticsView()
        {
            IRegion region = _regionManager.Regions["AccountRegion"];
            var view = _containerExtension.Resolve<AccountStatisticsSettingsView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenAccountSecuritySettinView()
        {
            IRegion region = _regionManager.Regions["AccountRegion"];
            var view = _containerExtension.Resolve<AccountSecuritySettingView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenAccountPersonalSettinView()
        {
            IRegion region = _regionManager.Regions["AccountRegion"];
            var view = _containerExtension.Resolve<AccountPersonalSettingView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }
    }
}
