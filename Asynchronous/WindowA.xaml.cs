using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Asynchronous
{
    /// <summary>
    /// Interaction logic for WindowA.xaml
    /// </summary>
    public partial class WindowA : Window
    {
        public WindowA()
        {
            InitializeComponent();
        }

        
        async Task<int> GetTotalSize(string[] uris)
        {
            IEnumerable<Task<int>> downloadTasks = uris.Select(async uri => ( await new WebClient().DownloadDataTaskAsync(uri)).Length);

            int[] contentsLengths = await Task.WhenAll(downloadTasks);
            return contentsLengths.Sum();
        }
    }
}
