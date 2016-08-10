using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkengines.Forex {
	public class OHLC {
		public virtual DateTime DateTime { get; set; }
		public virtual decimal Open { get; set; }
		public virtual decimal High { get; set; }
		public virtual decimal Low { get; set; }
		public virtual decimal Close { get; set; }
		public virtual int Volume { get; set; }
		public virtual int TickVolume { get; set; }
	}
}
