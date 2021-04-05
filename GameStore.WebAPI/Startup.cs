using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.Contracts;
using GameStore.BLL.Implementation;
using GameStore.DataAccess.Context;
using GameStore.DataAccess.Contracts;
using GameStore.DataAccess.Implementations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // BLL

            services.Add(new ServiceDescriptor(typeof(IGameCreateService), typeof(GameCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGameGetService), typeof(GameGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGameUpdateService), typeof(GameUpdateService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(ICustomerCreateService), typeof(CustomerCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICustomerGetService), typeof(CustomerGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICustomerUpdateService), typeof(CustomerUpdateService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IOrderCreateService), typeof(OrderCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOrderGetService), typeof(OrderGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOrderUpdateService), typeof(OrderUpdateService), ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IGameDataAccess), typeof(GameDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICustomerDataAccess), typeof(CustomerDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IOrderDataAccess), typeof(OrderDataAccess), ServiceLifetime.Transient));

            // DataBase Context
            services.AddDbContext<GameStoreContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("GameStore"),
                    o => o.ServerVersion(new Version(10, 4),
                        Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
