using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TariffComparison.Core;
using TariffComparison.Data;
using TariffComparison.Infrastructure;
using TariffComparison.Items;
using System.Reflection;

namespace TariffComparison
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersCustom()
                    .AddValidators(typeof(ItemIdentifier));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(ItemIdentifier)));

            services.AddServices(typeof(CoreIdentifier));

            services.AddSwaggerCustom();

            ConfigureDatabase(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorHandler();

            app.UseRouting();

            app.UseEndpoints(ep =>
            {
                ep.MapControllers();
            });

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerCustom();

            if (Environment.EnvironmentName == "Docker")
            {
                Initializer.InitializeDatabase(app);

                Initializer.InitializeDatas(app);
            }
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PgSql"), x =>
            {
                x.MigrationsAssembly(typeof(DataIdentifier).Namespace);
                x.MigrationsHistoryTable("ef_migrations", "public");
            }));

            services.AddScoped(typeof(DbContext), typeof(ApplicationContext));
        }
    }
}
