using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server.Forex
{
    public class ForexServices
    {
		protected ForexDbContext ForexDbContext { get; }
		public ForexServices(ForexDbContext forexDbContext) {
			ForexDbContext = forexDbContext;
		}
		public void ImportCurrencies(IEnumerable<Currency> currencies) {
			ForexDbContext.Currencies.AddRange(currencies);
		}
    }
}
