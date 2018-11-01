using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ngtryout.DB;
using Ngtryout.Infrastructure;
using Ngtryout.Models;

namespace Ngtryout
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataRepository, DataRepository>(options =>
            {
                var context = options.GetRequiredService<DataContext>();
                return new DataRepository(context);
            });

            var conn = Configuration.GetConnectionString("DataConn");
            services.AddDbContext<DataContext>(o => o.UseSqlServer(conn));

            services.AddSignalR();

            services.AddCors(o => o.AddPolicy(
                "CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4200");
                })
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<DataHub>("data");
            });

            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
