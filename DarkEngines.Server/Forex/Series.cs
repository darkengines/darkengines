using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkEngines.Server.Forex {
	public class Series {
		public Currency LeftCurrency { get; set; }
		public Currency RightCurrency { get; set; }
		public long TickPeriod { get; set; }
		public ICollection<OHLC> Data { get; }
		public override string ToString() {
			var period = new TimeSpan(TickPeriod);
			var PeriodName = (period.TotalDays >= 31) ? "M{period.TotalDays/31}"
				: (period.TotalDays >= 7) ? $"W{period.TotalDays / 7}"
				: (period.TotalDays >= 1) ? $"D{period.TotalDays}"
				: (period.TotalHours >= 1) ? $"H{period.TotalHours}"
				: $"M{period.TotalHours}";
			return $"{LeftCurrency}{RightCurrency} {PeriodName}";
		}
	}
}
