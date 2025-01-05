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

namespace AsyncConcurrency
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownloadSync();
            var elapseMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapseMs}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadAsync();
            var elapseMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapseMs}";
        }

        private async void executeParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();


            await RunDownloadParallelAsync();
            var elapseMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapseMs}";
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>();

            resultWindow.Text = "";

            output.Add("https://www.yahoo.com");
            output.Add("https://www.wired.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://aws.amazon.com");
            output.Add("https://github.com/edgarslima");
            output.Add("https://www.tabnews.com.br");

            return output;
        }

        private void RunDownloadSync()
        {
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(results);
            }

        }

        private async Task RunDownloadParallelAsync()
        {
            List<string> websites = PrepData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in websites)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(site)));

            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }

        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {

            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            var watch = System.Diagnostics.Stopwatch.StartNew();


            try
            {
                output.WebsiteUrl = websiteURL;
                output.WebsiteData = client.DownloadString(websiteURL);

            }
            catch (Exception ex)
            {
                output.WebsiteData = ex.Message;
            }

            var elapseMs = watch.ElapsedMilliseconds;

            output.TotalMilliseconds = elapseMs;
            return output;

        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultWindow.Text += $"{data.WebsiteUrl } downloaded: {data.WebsiteData.Length } characters long | Total milliseconds: {data.TotalMilliseconds} . { Environment.NewLine}";

        }
    }
}
