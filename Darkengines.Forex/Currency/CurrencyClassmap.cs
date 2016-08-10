using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkengines.Forex
{
	public class CurrencyClassMap: ClassMap<Currency>
	{
		public CurrencyClassMap()
		{
			Map(currency => currency.Code);
			Map(currency => currency.DecimalDigits);
			Map(currency => currency.Name);
			Map(currency => currency.NamePlural);
			Map(currency => currency.Symbol);
			Map(currency => currency.SymbolNative);
		}
	}
}
