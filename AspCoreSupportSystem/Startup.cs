using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSupportSystem.CustomValidations;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfSqlServer;
using Entities.Dbcontext;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace AspCoreSupportSystem
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //DBCONTEXT
            services.AddDbContext<AppDbContext>(_ => _.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));


            //IDENTITY
            services.AddIdentity<User, Role>(_ =>
            {
                _.Password.RequireDigit = false; //SAYI 
                _.Password.RequireLowercase = false; //K���K KARAKTER
                _.Password.RequireNonAlphanumeric = false; //NON ALPHA NUMERIC
                _.Password.RequireUppercase = false; //B�Y�K KARAKTER
                _.Password.RequiredLength = 4; //M�N UZUNLUK


                _.User.AllowedUserNameCharacters = "abc�defg�h�ijklmno�pqrstu�vwxyzABC�DEFG�H�IJKLMNO�PQRST�UVWXYZ0123456789 -.@_";

                _.User.RequireUniqueEmail = true;



            }).AddPasswordValidator<CustomPasswordValidations>()
                .AddUserValidator<CustomUserValidations>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            //LOG�N OLDU�UMUZDA COOKIE OTOMATIK KAYDED�LECEK.
            CookieBuilder cookieBuilder = new CookieBuilder()
            {
                Name = "Login",                                  //COOK�E �SM�
                HttpOnly = false,                                //CL�ENTDENDE COOK�YE ER���LS�N
                SameSite = SameSiteMode.Lax,                     //ALT S�TELERDEN ER���LEB�LS�N
                SecurePolicy = CookieSecurePolicy.SameAsRequest  //ALWAYS --> HTTPS, SAMEASERQUEST --> HTTP-HTTPS, NONE--> HTTP

            };


            //COOKIE CONF
            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Login");
                opts.LogoutPath = new PathString("/Logout");
                opts.AccessDeniedPath = new PathString("/AccessDenied");

                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan = TimeSpan.FromDays(30); //COOK�E �MR�

            });


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICityDal, EfCityDal>();
            services.AddScoped<IAccountDal, EfAccountDal>();
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IPetitionDal, PetitionDal>();
            services.AddScoped<IPetitionService, PetitionManager>();
            services.AddScoped<IContentDal, ContentDal>();
            services.AddScoped<IContentService, ContentManager>();
            services.AddScoped<IDocumentDal, DocumentDal>();
            services.AddScoped<IDocumentService, DocumentManager>();
            //MVC
            services.AddMvc(_ => _.EnableEndpointRouting = false);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();  //ALDI�IMIZ HATAYLA �LG�L� A�IKLAYICI B�LG�LER
            app.UseStatusCodePages();         //��ER�K D�NMEYEN SAYFALARDA B�Z� HATA KODUYLA B�LG�LEND�R�R
            app.UseStaticFiles();
            app.UseAuthentication();          //IDENTITY YAPISI ���N
            app.UseMvc(configureRoutes);
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default", "{area:exists}/{Controller=User}/{Action=Index}");
            routeBuilder.MapRoute("UserRoute", "{Controller=User}/{Action=Index}");
        }
    }
}
