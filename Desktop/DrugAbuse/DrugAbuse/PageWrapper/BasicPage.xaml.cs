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

namespace DrugAbuse
{
	public partial class BasicPage : UserControl
	{
        private String _title;
        private Boolean _possibleGoBack;

        public BasicPage()
		{
			this.InitializeComponent();
            _title = "DrugAbuse";
            _possibleGoBack = false;
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #region Setters & Getters
        public void setTitle(String title)
        {
            _title = title;
            PageTitle.Title.Text = title;
        }
		
        public String getTitle()
        {
            return this._title;
        }

        public void setPossibleGoBack(Boolean possible)
        {
            this._possibleGoBack = possible;
            PageNavigation.Button_Back.IsEnabled = possible;
        }

        public Boolean isPossibleGoBack() 
        {
            return this._possibleGoBack;
        }

        #endregion Setters & Getters

        public void OnClickClose(object sender, RoutedEventArgs e)
		{
            Application.Current.MainWindow.Close();
		}

        public void OnClickBackwards(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PreviousPage();
            
        }

        public void OnClickHelp(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GoToHelpPage();
        }

        public void OnClickMoveWindow(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).DragMove();
		}
    }
}