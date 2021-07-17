using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.Services;

namespace Shop
{
    public class Startup
    {
        //�������� ����������-�������� � ������� JSON-�����
        private readonly IConfigurationRoot configuration;
        public Startup(IWebHostEnvironment hosting)
        {
            configuration = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddWordPress(options =>
            //{
            //    options.DbHost = "localhost";
            //    options.DbName = "shop_wordpress";
            //    options.DbUser = "root";
            //    options.DbPassword = "";
            //    options.DbTablePrefix = "wp_";
            //});

            //services.AddHostedService<WarningBackgroundService>();
            services.AddDbContext<AppDBContent>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddMvcCore(option => option.EnableEndpointRouting = false).AddRazorViewEngine(); //option => option.EnableEndpointRouting=false 
                                                                                                      //.AddRazorViewEngine()

            services.AddDbContext<AppDBIdentity>(o => o.UseSqlServer(configuration.GetConnectionString("IdentityDBConnection")));
            services.AddDefaultIdentity<IdentityUser>(opt =>
            {
                opt.Password.RequireDigit = true; //������ �� ����
                opt.Password.RequiredLength = 5; //������ ������
                opt.Password.RequireUppercase = true; //����������� ���� ����� ������ ���� �������
                opt.Lockout.MaxFailedAccessAttempts = 5; //���������� � ���������� ������� ����� � ����������
                opt.User.RequireUniqueEmail = true; //���������� Email
                opt.SignIn.RequireConfirmedEmail = false; //������������� ����� �����
            })
            .AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDBContent>();
            

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped(sp => ShopCart.GetCart(sp)); //������ ��� ����� ������ ������ ������ ������������ ��� �������
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();

            services.AddTransient<IOrders, OrdersRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWordPress();

            app.UseSession();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            //app.UseMvcWithDefaultRoute(); - ������� ����� ���

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes => 
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller="Car", Action="List" });
            });

            //�������� � �� ���� ������-�� �������
            //using(var scope = app.ApplicationServices.CreateScope())
            //{
            //    AppDBContent db = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            //    InitialDbObjects.InitialDB(db);
            //}
        }
    }
}
