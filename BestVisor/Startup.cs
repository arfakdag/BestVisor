using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestVisor.DbModels;
using BestVisor.Models.Data.Abstract;
using BestVisor.Models.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestVisor
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
            services.AddTransient<IKampanyaRepository, EfKampanyaRepository>();
            services.AddTransient<IMusterilerRepository, EfMusterilerRepository>();
            services.AddTransient<ISektorlerRepository, EfSektorlerRepository>();
            services.AddMvc();
            var connection = @"Data Source=DESKTOP-TQLP6O6;Initial Catalog=bestvisor;Integrated Security=True";
            services.AddDbContext<bestvisorContext>(options => options.UseSqlServer(connection));
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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Campaign}/{action=Index}/{id?}");
            });
        }
    }
}
