using Prism.DryIoc;
using Prism.Ioc;
using SupportChatApplication.ViewModels.Interface;
using SupportChatApplication.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SupportChatApplication.ViewModels;
using System.Windows;

namespace SupportChatApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainChatView>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IChatViewModel, ChatViewModel>();
        }
    }
}
