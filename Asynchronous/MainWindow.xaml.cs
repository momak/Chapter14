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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asynchronous
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button _button = new Button { Content = "Go" };
        Button _buttonW = new Button { Content = "Window" };
        TextBlock _results = new TextBlock();

        public MainWindow()
        {
            InitializeComponent();
            var panel = new StackPanel();
            panel.Children.Add(_button);
            panel.Children.Add(_buttonW);
            panel.Children.Add(_results);
            Content = panel;
            //_button.Click += (sender, args) => Go();
            _button.Click += (sender, args) =>
            {
                //_button.IsEnabled = false;
                Task.Run(Go1);
            };

            _buttonW.Click += _buttonW_Click;
        }

        private void _buttonW_Click(object sender, RoutedEventArgs e)
        {
            WindowA winA = new WindowA();
            winA.Show();
            this.Close();
        }

        private async void Go()
        {
            _results.Text = String.Empty;
            _button.IsEnabled = false;

            string[] urls = "www.albahari.com www.oreilly.com www.linqpad.net".Split();
            int totalLength = 0;
            try
            {
                foreach (string url in urls)
                {
                    var uri = new Uri($"http://{url}");
                    byte[] data = await new WebClient().DownloadDataTaskAsync(uri);
                    _results.Text += $"Length of {url} is {data.Length}{Environment.NewLine}";
                    totalLength += data.Length;
                }
                _results.Text += $"Total length: {totalLength}";
            }
            catch (Exception e)
            {
                _results.Text += $"Error: {e.Message}";
            }
            finally
            {
                _button.IsEnabled = true;
            }

        }

        private async Task Go1()
        {
            //await PrintAnswersToLife();
            //_results.Text += "Done";

            var task = PrintAnswersToLife();
            await task;
            _results.Text += "Done";
        }

        async Task PrintAnswersToLife()
        {
            int answer = await GetAnswersToLife();
            _results.Text += answer;
        }

        async Task<int> GetAnswersToLife()
        {
            //await Task.Delay(5000);
            //int answer = 21 * 2;
            //return answer;
            var task = Task.Delay(5000);
            await task;
            int answer = 21 * 2;
            return answer;
        }



        private Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

        }
    }
}
