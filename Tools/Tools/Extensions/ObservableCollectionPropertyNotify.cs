using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Extensions
{
    public class ObservableCollectionPropertyNotify<T> : ObservableCollection<T>
    {
        public void Refresh()
        {
            for (var i = 0; i < this.Count(); i++)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
}
