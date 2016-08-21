using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore;
using Npgsql;
using DarkEngines.Server.Forex;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DarkEngines.Server {
	public class Startup {
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) {
            services
            .AddEntityFrameworkNpgsql()
            .AddDbContext<ForexDbContext>(options => options.UseNpgsql("host=127.0.0.1;userid=postgres;password=2701104$reg2rt;database=forex"))
            .AddJsonSerializer()
            .AddHttpManagedServiceRequestHandler()
            .AddMyService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
			loggerFactory.AddConsole();

			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
            app.UseManagedServiceMiddleware();
			//app.Run(async (context) => {
			//	await context.Response.WriteAsync("Hello World!");
			//});
		}
	}
}
