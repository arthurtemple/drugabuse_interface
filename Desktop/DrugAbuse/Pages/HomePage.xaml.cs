using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace DrugAbuse
{
	public partial class HomePage : UserControl
    {
        #region static properties
        public static String TitleContent = "Home";
        #endregion

        Dictionary<string, string> urlMap;
        string request;

        private string downloadedFile;

        public HomePage()
		{
			this.InitializeComponent();
            progressBar.Visibility = System.Windows.Visibility.Hidden;
            Feedback.Visibility = System.Windows.Visibility.Hidden;
            urlMap = new Dictionary<String, String>();

            urlMap.Add("emergency", "http://www.bt.cdc.gov/");
            urlMap.Add("service"  , "http://drugabuse.herokuapp.com/info/show?request=");
            urlMap.Add("web"      , "../../Web/index.html");
		}

        #region OnClick Methods

        private void OnClickHelp(object sender, RoutedEventArgs e)
        {
           ((MainWindow)App.Current.MainWindow).GoToHelpPage();
        }

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {
            //((MainWindow)App.Current.MainWindow).GoToHelpPage();
        }

        private void OnClickPhone(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).GoToPhonePage();
        }
		
		private void OnClickPrevious(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).GoToPreviousDownloadPage();
        }
		
		private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
             if (e.Key == Key.Return)
            {
                OnClickResult(sender, e);
            }
        }
		
		private void OnClickResult(object sender, RoutedEventArgs e)
        {
            //Process.Start("SamplePDF1.pdf");
            request = UserRequest.Text.Trim();
            Console.WriteLine("user input= " + request);
            if (request == String.Empty)
            {
                Feedback.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            else
            {
                Feedback.Visibility = System.Windows.Visibility.Hidden;
                progressBar.Visibility = System.Windows.Visibility.Visible;

                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                string url = "http://drugabuse.herokuapp.com/info/show?request=" + request;

                if (!Directory.Exists(MainWindow.TEMP_FOLDER))
                {
                    Directory.CreateDirectory(MainWindow.TEMP_FOLDER);
                }
                downloadedFile = System.IO.Path.Combine(MainWindow.TEMP_FOLDER, request + MainWindow.FILE_EXTENSION);
                webClient.DownloadFileAsync(new Uri(url), downloadedFile);
            }
        }
		
		private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).setKeepHistory(true);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).setKeepHistory(false);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Visibility = System.Windows.Visibility.Visible;
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar.Visibility = System.Windows.Visibility.Hidden;
            Feedback.Text = "Download completed";
            Feedback.Visibility = System.Windows.Visibility.Visible;
            Process.Start(downloadedFile);
        }



        #endregion OnClick Methods

    }
}