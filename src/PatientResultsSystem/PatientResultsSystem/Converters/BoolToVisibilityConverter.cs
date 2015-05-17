using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PatientResultsSystem.Converters
{
	class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool && parameter is string)
			{
				if ((string) parameter == "VisibleOnTrue")
				{
					return (bool) value ? Visibility.Visible : Visibility.Collapsed;
				}

				if ((string) parameter == "CollapsedOnTrue")
				{
					return (bool) value ? Visibility.Collapsed : Visibility.Visible;
				}
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
