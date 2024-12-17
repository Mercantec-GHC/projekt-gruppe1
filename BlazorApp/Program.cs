using BlazorApp.Components;
using Domain.Models.DB;
using Domain.Models.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	            .AddCookie(options =>
	            {
		            options.Cookie.Name = "auth_token";
		            options.LoginPath = "/login";
                    options.Cookie.SameSite = SameSiteMode.Strict;
		            options.Cookie.MaxAge = TimeSpan.FromMinutes(180);
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.HttpOnly = true;
                });
           
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7130/") });
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton(new DBService(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IBoligService, BoligService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();
            app.UseAntiforgery();
            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}
