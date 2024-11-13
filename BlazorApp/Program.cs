using BlazorApp.Components;
using Domain.Models.DB;
using Domain.Models.Service;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton(new DBService(connectionString));

            builder.Services.AddScoped<IBoligService, BoligService>();
            var app = builder.Build(); 

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

  
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
