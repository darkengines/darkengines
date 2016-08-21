using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkEngines.Server.Forex {
	public class Currency {
		public int CurrencyId { get; set; }
		public string Symbol { get; set; }
		public string Name { get; set; }
		public string SymbolNative { get; set; }
		public int DecimalDigits { get; set; }
		public string Code { get; set; }
		public string NamePlural { get; set; }
		public override string ToString() {
			return Code;
		}
	}
}
