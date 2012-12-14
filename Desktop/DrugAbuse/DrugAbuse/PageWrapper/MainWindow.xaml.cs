using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DrugAbuse
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool keepHistory;

        public const string TEMP_FOLDER = @"..\..\..\temp\";
        public const string FILE_EXTENSION = ".pdf";

        public bool isKeepHistory()
        {
            return this.keepHistory;
        }

        public void setKeepHistory(bool keep)
        {
           this.keepHistory = keep;
        }

        public MainWindow()
        {
            InitializeComponent();
            GoToHomePage();
            keepHistory = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            
            // If does not want to keep history
            if (!keepHistory)
            {
                DirectoryInfo di = new DirectoryInfo(TEMP_FOLDER);
                Empty(di);
                Console.WriteLine("History cleaned");
            }
        }

        public void Empty(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }

        #region SetPage

        /// <summary>
        /// Change the page on the screen. Works like this :
        /// - MainWindow uses a BasicPage that contains already basic GUI
        /// - The page in argument is actually a UserControl, it will be placed
        /// in the pageTransitionControl of the BasicPage
        /// </summary>
        public void NextPage(UserControl page)
        {
            BasicPage wrapper = new BasicPage();
            wrapper.PageContent.Content = page;
            pageTransitionControl.NextPage(wrapper);
        }

        public void NextPage(UserControl page, String title)
        {
            BasicPage wrapper = new BasicPage();
            wrapper.setTitle(title);
            wrapper.setPossibleGoBack(false);
            wrapper.PageContent.Content = page;
            pageTransitionControl.NextPage(wrapper);
        }

        public void PreviousPage()
        {
            pageTransitionControl.PreviousPage();
        }

        #endregion SetPage

        #region Pages

        public void GoToHomePage()
        {
            pageTransitionControl.EmptyPageStack();
            NextPage(new HomePage(), HomePage.TitleContent);
        }

        public void GoToHelpPage()
        {
            NextPage(new HelpPage(), HelpPage.TitleContent);
        }

        public void GoToPhonePage()
        {
            NextPage(new PhonePage(), PhonePage.TitleContent);
        }
		
		public void GoToPreviousDownloadPage()
		{
			NextPage(new PreviousDownloadPage(), PreviousDownloadPage.TitleContent);
		}

        #endregion
    }
}
