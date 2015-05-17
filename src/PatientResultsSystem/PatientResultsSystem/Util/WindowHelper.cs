using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientResultsSystem.Util
{
	static class WindowHelper
	{
		//
		// Method to find a window in the application by type
		//
		public static Window FindWindow(Type windowType)
		{
			if (Application.Current.Windows.Count > 0)
			{
				foreach (Window window in Application.Current.Windows)
				{
					if (window.GetType() == windowType)
						return window;
				}
			}

			return null;
		}
	}
}
