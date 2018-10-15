using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KattisUtilities;
using KattisUtilities.HTML;
/// <summary>
/// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await
/// </summary>
namespace AsyncExampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = vm;
        }

        //KattisProblemVM vm = new KattisProblemVM();

      
        private void startButtonClick(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();
            var pm = DataContext as KattisProblemVM;
            pm.Pages.Clear();
            GrabAllKattis();
       
        }

        private void GrabAllKattis()
        {
            // Make a list of web addresses.  
            
            var pm = DataContext as KattisProblemVM;
            int id = 1;
            var lst = SetUpURLList();
            foreach (var lu in lst)
                pm.Pages.Add(new UrlItem(lu,id++));
           




        }

        private List<string> SetUpURLList()
        {
            List<string> urls = new List<string>
            {
                "https://open.kattis.com/problems",
                "https://open.kattis.com/problems?page=1",
                "https://open.kattis.com/problems?page=2",
                "https://open.kattis.com/problems?page=3",
                "https://open.kattis.com/problems?page=4",
                "https://open.kattis.com/problems?page=5",
                "https://open.kattis.com/problems?page=6",
                "https://open.kattis.com/problems?page=7",
                "https://open.kattis.com/problems?page=8",
                "https://open.kattis.com/problems?page=9",
                "https://open.kattis.com/problems?page=10",
                "https://open.kattis.com/problems?page=12",
                "https://open.kattis.com/problems?page=13",
                "https://open.kattis.com/problems?page=14",
                "https://open.kattis.com/problems?page=15",
                "https://open.kattis.com/problems?page=16",
                "https://open.kattis.com/problems?page=17",
                "https://open.kattis.com/problems?page=18",
                "https://open.kattis.com/problems?page=19"
            };
            
            //int i = 1;
            //if (vm == null)
            //    vm = new KattisProblemVM();
            //foreach (var s in urls )
            //{
            //    vm.Pages.Add(new UrlItem(s, i++));
            //}
            return urls;
        }


        // The actions from the foreach loop are moved to this async method.
        static int id = 0;
        async Task<int> ProcesKattissURL(string url, HttpClient client)
        {
            UrlItem urlItem = new UrlItem(url, id++);
            int n = await urlItem.Grab();
           
           
            int retVal = urlItem.Html.Length;
            var pm = DataContext as KattisProblemVM;
            pm.Pages.Add(new UrlItem(url, pm.Pages.Count + 1));

            this.resultsTextBox.Text = retVal.ToString();
            

            return retVal;
        }


        private void resultsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblTotal != null)
            lblTotal.Text  = resultsTextBox.Text.Length.ToString();
        }
    }
}
