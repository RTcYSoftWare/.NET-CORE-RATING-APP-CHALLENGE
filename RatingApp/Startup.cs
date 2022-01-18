using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RatingApp.Database;
using RatingApp.Interfaces;
using RatingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp
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
            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContextPool<RatingAppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RatingAppConnection")));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // cookie transaction services
            services.Configure<CookiePolicyOptions>(options => // coocike write to user pc transaction services
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IBlogController, BlogControllerService>();
            services.AddScoped<IProductController, ProductControllerService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "blog",
                    pattern: "/blogs",
                    defaults: new { controller = "Blog", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "singleBlog",
                    pattern: "/blogs/{slug?}",
                    defaults: new { controller = "Blog", action = "SingleBlog" });

                endpoints.MapControllerRoute(
                    name: "blogCommentAdd",
                    pattern: "/blogs/saveblogcomment",
                    defaults: new { controller = "Blog", action = "SaveBlogComment" });

                endpoints.MapControllerRoute(
                    name: "singleProduct",
                    pattern: "/products/{slug?}",
                    defaults: new { controller = "Products", action = "SingelProduct" });
                endpoints.MapControllerRoute(
                    name: "productRatingAdd",
                    pattern: "/products/saveproductrating",
                    defaults: new { controller = "Products", action = "SaveProductRating" });

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "/login",
                    defaults: new { controller = "User", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "register",
                    pattern: "/register",
                    defaults: new { controller = "User", action = "Register" });
               
                endpoints.MapControllerRoute(
                    name: "logout",
                    pattern: "/logout",
                    defaults: new { controller = "User", action = "Logout" });
            });
        }
    }
}
