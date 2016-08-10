using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkengines.Forex {
	public class Currency {
		public virtual string Symbol { get; set; }
		public virtual string Name { get; set; }
		public virtual string SymbolNative { get; set; }
		public virtual int DecimalDigits { get; set; }
		public virtual string Code { get; set; }
		public virtual string NamePlural { get; set; }
		public override string ToString() {
			return Code;
		}
	}
}
