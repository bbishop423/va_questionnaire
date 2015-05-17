using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.ViewModels
{
	abstract class ViewModelBase : INotifyPropertyChanged
	{
		//
		// INotifyPropertyChanged Implementations
		//
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
