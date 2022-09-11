using BankApplication.Events;
using BankApplication.Views;
using MessageBoxWidget;
using MessageBoxWidget.Model;
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
    public class MainStartViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;
        private readonly IEventAggregator _eventAggregator;

        public ICommand OpenCardsViewButtonCommandClick { get; set; }
        public ICommand OpenTopMenuHomeViewButtonCommandClick { get; set; }
        public ICommand OpenActionHistoryViewButtonClickCommand { get; set; }
        public ICommand OpenBlikViewButtonClickCommand { get; set; }
        public ICommand OpenTopMenuTransactionViewButtonClickCommand { get; set; }
        public ICommand OpenTopMenuDepositViewButtonCommandClick { get; set; }
        public ICommand OpenTopMenuAccountViewButtonCommandClick { get; set; }
        public ICommand CloseApplicationCommand { get; set; }

        public MainStartViewModel(IRegionManager regionManager, IContainerExtension containerExtension, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _containerExtension = containerExtension;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<ErrorEvent>().Subscribe(ShowError);
            _eventAggregator.GetEvent<SuccessEvent>().Subscribe(ShowMessage);
            _eventAggregator.GetEvent<NotFoundEvent>().Subscribe(ShowNotFound);
            _eventAggregator.GetEvent<WarningEvent>().Subscribe(ShowWarning);

            OpenCardsViewButtonCommandClick = new DelegateCommand(OpenCardsView);
            OpenTopMenuHomeViewButtonCommandClick = new DelegateCommand(OpenTopMenuHome);
            OpenActionHistoryViewButtonClickCommand = new DelegateCommand(OpenActionHistoryView);
            OpenBlikViewButtonClickCommand = new DelegateCommand(OpenBlikView);
            OpenTopMenuTransactionViewButtonClickCommand = new DelegateCommand(OpenTransactionView);
            OpenTopMenuDepositViewButtonCommandClick = new DelegateCommand(OpenTopMenuDeposit);
            OpenTopMenuAccountViewButtonCommandClick = new DelegateCommand(OpenTopMenuAccount);
            CloseApplicationCommand = new DelegateCommand(CloseApplication);
        }

        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        private void ShowMessage(string message)
        {
            bool? result = new CustomMessageBox(message, MessageType.Success).ShowDialog();
        }

        private void ShowError(Exception exception)
        {
            bool? result = new CustomMessageBox(exception, MessageType.Error).ShowDialog();
        }

        private void ShowNotFound(string message)
        {
            bool? result = new CustomMessageBox(message, MessageType.NotFound).ShowDialog();
        }

        private void ShowWarning(string message)
        {
            bool? result = new CustomMessageBox(message, MessageType.Warning).ShowDialog();
        }

        private void OpenCardsView()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<CardsView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenTopMenuHome()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<HomeView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }
        private void OpenActionHistoryView()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<ActionHistoryView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }
        private void OpenBlikView()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<BliKOperationView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenTransactionView()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<TransactionView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenTopMenuDeposit()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<DepositView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }

        private void OpenTopMenuAccount()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<AccountView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }
    }
}
