using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mvc1.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace mvc1
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            var host = Configuration["DBHOST"] ?? "localhost";
            var port = Configuration["DBPORT"] ?? "3306";
            var password = Configuration["DBPASSWORD"] ?? "numsey";

            //    services.AddDbContext<AppDbContext>(options =>                        
            //      options.UseMySql($"server={host};userid=root;pwd={password}; port={port};database=produtosdb"));

            services.AddDbContextPool<AppDbContext>(
                         dbContextOptions => dbContextOptions
                             .UseMySql(
                                 // Replace with your connection string.
                                 $"Server={host};Database=produtosdb;user=root;Password={password};port={port};",
                                 // Replace with your server version and type.
                                 // For common usages, see pull request #1233.
                                 new MySqlServerVersion(new Version(5,7)), // use MariaDbServerVersion for MariaDB
                                 mySqlOptions => mySqlOptions
                                     .CharSetBehavior(CharSetBehavior.NeverAppend).EnableRetryOnFailure())
                             // Everything from this point on is optional but helps with debugging.
                             .EnableSensitiveDataLogging()
                             .EnableDetailedErrors()
                             
            );


            services.AddTransient<IRepository, ProdutoRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //Populadb.IncluiDadosDB(app);
            app.UseRouting();

            app.UseAuthorization();
     

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
