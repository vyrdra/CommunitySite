using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CommunitySite.Models;
using CommunitySite.Models.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CommunitySite.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CommunitySite
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:CommunityForum:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:CommunityForumIdentity:ConnectionString"]));

            services.AddIdentity<ParkMember, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc();
            services.AddTransient<IParkMemberRepository, ParkMemberRepository>();
            services.AddTransient<IForumMessageRepository, ForumRepository>();
            services.AddMemoryCache();
            services.AddSession();

           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "news",
                    template: "{controller=News}/{action=News}");
                routes.MapRoute(
                    name: "map",
                    template: "{controller=Map}/{action=Map}");
                routes.MapRoute(
                    name: "forum",
                    template: "{controller=Forum}/{action=Forum}");//try adding id
                routes.MapRoute(
                    name: "login",
                    template: "{controller=Login}/{action=Login}");
            });

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            
            app.UseMvcWithDefaultRoute();

            
            SeedData.EnsurePopulated(app).Wait();
            //Wait waits for the Task to finish....
            //IdentitySeedData.EnsurePopulated(app).Wait();

          
        }
    }
}
