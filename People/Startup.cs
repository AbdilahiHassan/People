using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using People.DataBase;
using People.Models.MetaData;
using People.Models.Repo;
using People.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace People
{
    public class Startup
    {
        //Access to appsettings.json in my Startup class file (Constructor Injection).
        public IConfiguration Configuration { get; }
  
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection to database
            services.AddDbContext<PeopleDbContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Services IOC/inversion of contorl
            services.AddScoped<IPeopelService, PeopleService>();           
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPersonLanguageService, PersonLanguageService>();
            // services.AddSingleton<IPeopleRepo, InMemoryPeopleRepo>();
            //Repo Inversion of control

            //services.AddControllersWithViews();
            services.AddScoped<ICityRepo, DataBaseCityRepo>();
            services.AddScoped<ICountryRepo, DataBaseCountryRepo>();
           services.AddScoped<IPeopleRepo, DataBasePeopleRepo>();
            services.AddScoped<ILanguageRepo, DBLanguageRepo>();
            services.AddScoped<IPersonLanguageRepo, DBPersonLanguageRepo>();
            services.AddMvc();
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
               
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
