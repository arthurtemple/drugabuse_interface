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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DrugAbuse
{
	/// <summary>
	/// Logique d'interaction pour ResultPage.xaml
	/// </summary>
	public partial class PreviousDownloadPage : UserControl
	{
        #region static properties
        public static String TitleContent = "Previous searches";
        #endregion

       // AdobePdfViewer adobePdfView;

		public PreviousDownloadPage()
		{
			this.InitializeComponent();
            LoadFilesIntoList();
		}

        private void LoadFilesIntoList()
        {

            DirectoryInfo di = new DirectoryInfo(MainWindow.TEMP_FOLDER);
            FileInfo[] filePaths = di.GetFiles("*" + MainWindow.FILE_EXTENSION);
            foreach (FileInfo f in filePaths)
            {
                ((ListBox)listOfFiles).Items.Add(System.IO.Path.GetFileNameWithoutExtension(f.Name));
            }
        }
		
		private void OnClickSavePdf(object sender, RoutedEventArgs e)
        {
            string select = listOfFiles.SelectedItem as string;
            Console.WriteLine("select=" + select);
        }
		
		private void OnClickPrintPdf(object sender, RoutedEventArgs e)
        {
            // TODO
        }
		
		private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(MainWindow.TEMP_FOLDER);
            Empty(di);
            listOfFiles.Items.Clear();
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
	}
}