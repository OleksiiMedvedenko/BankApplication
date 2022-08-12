using BankApplication.ViewModels;
using BankApplication.ViewModels.Interface;
using BankApplication.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<Views.MainStartView>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Views
            containerRegistry.Register<ICardsViewModel, CardsViewModel>();
            containerRegistry.Register<IHomeViewModel, HomeViewModel>();
            containerRegistry.Register<IActionHistoryViewModel, ActionHistoryViewModel>();
            containerRegistry.Register<IBliKOperationViewModel, BliKOperationViewModel>();
        }
    }
}
