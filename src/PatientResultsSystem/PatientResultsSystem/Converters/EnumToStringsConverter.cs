using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PatientResultsSystem.Models;

namespace PatientResultsSystem.Converters
{
	class EnumToStringsConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType() == typeof (UserTypes))
			{
				return Enum.GetName(typeof (UserTypes), (int)value);
			}

			return null;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Not needed
			return null;
		}
	}
}
