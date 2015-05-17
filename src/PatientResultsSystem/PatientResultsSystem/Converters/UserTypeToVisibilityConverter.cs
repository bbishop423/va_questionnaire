using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using PatientResultsSystem.Models;

namespace PatientResultsSystem.Converters
{
	class UserTypeToVisibilityConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType() == typeof (UserTypes))
			{
				if ((UserTypes) value == UserTypes.Administrator)
					return Visibility.Visible;
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
