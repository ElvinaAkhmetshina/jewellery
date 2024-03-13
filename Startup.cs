using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using jewellery.Data.interfaces;
using jewellery.Data.Repository;
using jewellery.Data.Models;
using jewellery.Data;
using Microsoft.EntityFrameworkCore;
//using new_shop.Data.Interfaces;
//using new_shop.Data.Mocks;
//using new_shop.Data;
//using Microsoft.EntityFrameworkCore;

//using new_shop.Data.Models;
//using new_shop.Data.Repository;
//using new_shop.Data.interfaces;

namespace new_shop
{
    public class Startup
    {


        ////добавляем джейсоновский файл, в котором мы храним строку для подключения к бд
        private IConfigurationRoot _confsting;
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confsting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confsting.GetConnectionString("DefaultConnection")));

            ////связываем интерфейс и класс который его реализует
            services.AddTransient<IAllJewelry, JewelryRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();

        }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();

            ////задание ссылок для страниц
            ////шаблон для задания ссылок для страниц
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Jewelry/{action}/{category?}", defaults: new { Controller = "Jewelry", action = "List" });
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

        }

    }
}
