using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkengines.Forex {
	public class OHLCClassMap: ClassMap<OHLC> {
		public OHLCClassMap() {
			Map(ohlc => ohlc.DateTime);
			Map(ohlc => ohlc.Open);
			Map(ohlc => ohlc.High);
			Map(ohlc => ohlc.Low);
			Map(ohlc => ohlc.Close);
			Map(ohlc => ohlc.Volume);
			Map(ohlc => ohlc.TickVolume);
		}
	}
}
