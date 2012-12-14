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
	/// Logique d'interaction pour PhonePage.xaml
	/// </summary>
	public partial class PhonePage : UserControl
	{
        #region static properties
        public static String TitleContent = "Phone numbers";
        #endregion

		public PhonePage()
		{
			this.InitializeComponent();
		}
	}
}