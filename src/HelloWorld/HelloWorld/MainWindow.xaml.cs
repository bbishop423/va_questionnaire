using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace HelloWorld
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private HelloWorldDataContext dataContext;

		public MainWindow( )
		{
			InitializeComponent( );
			
			dataContext = new HelloWorldDataContext();
			DisplayBlock.Text = QueryDatabase("Display");

		}

		private string QueryDatabase(string key)
		{
			if (dataContext != null)
			{
				return (from str in dataContext.DisplayStrings
					where str.Key == key
					select str.Value).First();
			}

			return String.Empty;
		}
	}
}
