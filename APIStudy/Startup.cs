using APIStudy.Handlers;
using APIStudy.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Net.Http;


namespace APIStudy
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
            services.AddHttpContextAccessor();

            var clientHandler = new HttpClientHandler
            { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } };

            services.AddTransient<BearerTokenMessageHandler>();

            services.AddRefitClient<IUserService>()
                .AddHttpMessageHandler<BearerTokenMessageHandler>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(Configuration.GetValue<string>("UrlAPIStudy"));
                }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

            services.AddRefitClient<ICourseServices>()
                .ConfigureHttpClient(c =>
                 {
                     c.BaseAddress = new Uri(Configuration.GetValue<string>("UrlAPIStudy"));
                 }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                    options.AccessDeniedPath = "/User/Login";
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
            app.UseAuthentication();


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
