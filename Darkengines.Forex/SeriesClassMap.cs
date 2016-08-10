using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkengines.Forex.Series {
	public class SeriesClassMap: ClassMap<Series> {
		public SeriesClassMap() {
			Map(series => series.TickPeriod);
			References(series => series.LeftCurrency);
			References(series => series.RightCurrency);
			HasMany(series => series.Data);
		}
	}
}
