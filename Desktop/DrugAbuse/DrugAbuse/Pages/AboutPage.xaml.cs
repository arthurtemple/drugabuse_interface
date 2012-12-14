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
	/// Logique d'interaction pour HelpPage.xaml
	/// </summary>
	public partial class HelpPage : UserControl
	{
        public static String TitleContent = "About this application";

		public HelpPage()
		{
			this.InitializeComponent();
            Text_Web.Text = "This application search information from trustworthy websites.";
			Text_About.Text="This application is strictly anonymous, and does not keep"
                +" logs and traces. HTTP requests are crypted, so are Downloaded PDF files";
            Text_Dev.Text = "This application was made for T-121.5300 User Interface Construction.";
		}
	}
}