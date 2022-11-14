using System.Net;

namespace testapp
{
    public class Program
    {
        // a change
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {

                serverOptions.ConfigureEndpointDefaults(listenOptions =>
                {

                    listenOptions.UseHttps("/app/k8svc.pfx", "tvxs721#3");

                });
                serverOptions.Listen(IPAddress.Any, 443, listenOptions =>
                {
                    listenOptions.UseConnectionLogging();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}