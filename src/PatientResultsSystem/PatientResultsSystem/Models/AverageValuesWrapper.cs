using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
	class AverageValuesWrapper
	{
		// The average values per group
		private long _avgTotal;
        private long _avgBasic;
        private long _avgAdvanced;
        private long _avgAdjust;
        private long _avgAided;

		// Binding for the average for each group
        public long AvgTotal { get { return _avgTotal; } }
        public long AvgBasic { get { return _avgBasic; } }
        public long AvgAdvanced { get { return _avgAdvanced; } }
        public long AvgAdjust { get { return _avgAdjust; } }
        public long AvgAided { get { return _avgAided; } }

        public AverageValuesWrapper ( long total, long basic, long advanced, long adjust, long aided )
		{
			_avgTotal = total;
			_avgBasic = basic;
			_avgAdvanced = advanced;
			_avgAdjust = adjust;
			_avgAided = aided;
		}
	}
}
