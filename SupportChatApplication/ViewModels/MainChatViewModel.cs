using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SupportChatApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SupportChatApplication.ViewModels
{
    public class MainChatViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;

        public ICommand OpenRegion { get; set; }

        public MainChatViewModel(IRegionManager regionManager, IContainerExtension containerExtension)
        {
            OpenRegion = new DelegateCommand(OpenChatView);
            _regionManager = regionManager;
            _containerExtension = containerExtension;
        }

        private void OpenChatView()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _containerExtension.Resolve<ChatView>();

            foreach (var v in region.Views)
            {
                region.Remove(v);
            }

            region.Add(view);
        }
    }
}
