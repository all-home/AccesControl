using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkersDB.Models;
using Microsoft.Extensions.Hosting;
using FileSave.Models;
using WorkersDB.Interfaces;
using WorkersDB;
using FileSave.interfaces;
using FileSave.GRUD;
using FileSave;
using BusinessLogic.Interfaces;
using BusinessLogic.WorkersRepo;
using BusinessLogic.SearchWorkerByTagID;
using ProfilesDB.Interfaces;
using ProfilesDB.Model;
using ProfilesDB;
using BusinessLogic.Profiles;
using AccesControl.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AccesControl
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
           /* services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });*/
            services.AddDbContext<WorkerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<StatisticsContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<FileContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<ProfileContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IGRUDWorker, WorkersRepository>();
            services.AddScoped<IFilesDB, FilesDB>();
            services.AddScoped<IFileUGD, FiileDelGetUpload>();
            services.AddScoped<IWorkersRepo, Workers>();
            services.AddScoped<ISearchByTagID, GetWorkerByTag>();
            services.AddScoped<IProfileRepo, ProfilesRepo>();
            services.AddScoped<IStat, SatisticsRepository>();
            services.AddScoped<IProfiles, ProfileRepo>();
            services.AddRazorPages();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => //CookieAuthenticationOptions
               {
                  options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
              });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment   env)
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
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            //app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
