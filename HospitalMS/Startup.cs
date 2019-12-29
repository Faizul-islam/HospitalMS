using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalMS.Data;
using HospitalMS.Models.AccountModels;
using HospitalMS.Models.EmployeeModels;
using HospitalMS.Models.PersonModels;
using HospitalMS.Models.PositionModels;
using HospitalMS.Models.SpecialityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalMS
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
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Configure and use SQL Server with entity framework core.
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HospitalMSDbConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();


            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache

            services.AddSession();

            services.AddScoped<IPersonRepository, SQLPersonRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IAccountRepository, SQLAccountRepository>();
            services.AddScoped<ISpecialityRepository, SQLSpecialityRepository>();
            services.AddScoped<IPositionRepository, SQLPositionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
