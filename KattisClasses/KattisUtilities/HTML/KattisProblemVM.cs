using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUtilities.HTML
{
    public class KattisProblemVM : INotifyPropertyChanged
    {
        private ObservableCollection<UrlItem> pages;

        public event PropertyChangedEventHandler PropertyChanged;

        public KattisProblemVM()
        {
            Pages = new ObservableCollection<UrlItem>();
            Pages.CollectionChanged += Pages_CollectionChanged;
           // Pages.Add(new UrlItem("www.google.com", 1));
           // Pages.Add(new UrlItem("www.microsoft.com", 2));

        }

        private async void  Pages_CollectionChanged(object sender,
                                             System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
                case (System.Collections.Specialized.NotifyCollectionChangedAction.Add):
                    foreach (UrlItem it in e.NewItems)
                    {
                        it.PropertyChanged += It_PropertyChanged;
                        await it.Grab();
                    }
                    break; 
            }
        }

        private void It_PropertyChanged(object sender, 
                                        System.ComponentModel.PropertyChangedEventArgs e)
        {
            var it = sender as UrlItem;
            if (e.PropertyName == "IsDownLoading")
            {
                if (it.IsDownLoading == false)
                {
                    int i = 0;
                    Console.WriteLine($"Done Downloading [{it.ID}] @ [{DateTime.Now}]");
                }
            }
        }

        public ObservableCollection<UrlItem> Pages { get => pages; set => pages = value; }
    }
}
