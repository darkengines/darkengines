using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server.Forex
{
    public class ForexDbContext: DbContext
    {
		public ForexDbContext(DbContextOptions<ForexDbContext> options) : base(options) { }
		public DbSet<Currency> Currencies { get; }
    }
}
