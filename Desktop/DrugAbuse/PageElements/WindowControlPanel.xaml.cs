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

namespace DrugAbuse
{
	/// <summary>
	/// Logique d'interaction pour WindowControlPanel.xaml
	/// </summary>
	public partial class WindowControlPanel : UserControl
	{
        protected Boolean isMaximized;

		public WindowControlPanel()
		{
			this.InitializeComponent();
            isMaximized = false;
		}
		
		private void OnClickClose(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Close();
        }
		
		private void OnClickMaximize(object sender, RoutedEventArgs e)
        {
            if (!isMaximized)
            {
                ((MainWindow)App.Current.MainWindow).WindowState = System.Windows.WindowState.Maximized;
                isMaximized = true;
            }
            else
            {
                ((MainWindow)App.Current.MainWindow).WindowState = System.Windows.WindowState.Normal;
                isMaximized = false;
            }
        }

        private void OnClickMinimized(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).WindowState = System.Windows.WindowState.Minimized;
        }
		
	}
}