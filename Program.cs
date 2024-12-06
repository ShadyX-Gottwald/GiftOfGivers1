using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using GiftOfGivers1.Data;
using GiftOfGivers1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Supabase;

namespace GiftOfGivers1;
public class Program {
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = "Server=tcp:simple-db-server.database.windows.net,1433;" +
           "Initial Catalog=GoGDB;Persist Security Info=False;User ID=ST10075891@vcconnect.edu.za;" +
        "Password=Happydays@2024;MultipleActiveResultSets=False;Encrypt=True;" +
           "TrustServerCertificate=False;Connection Timeout=30;";

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers();

        // Add session services (enabling session management)
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(10); // Set session timeout duration
            options.Cookie.HttpOnly = true; // Protects the session cookie from client-side scripts
            options.Cookie.IsEssential = true; // Required for GDPR compliance
        });


        // Add services to the container.
        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("EntraID"));

         builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddAuthorization(options => {
            // By default, all incoming requests will be authorized according to the default policy.
            options.FallbackPolicy = options.DefaultPolicy;
        });

       
        builder.Services.AddRazorPages()
            .AddMicrosoftIdentityUI();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Enable session middleware
        app.UseSession();  // <-- This enables session management in the app

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllers();
        
       
        app.MapRazorPages();

        //Disasters Minimal API's 

        app.MapGet("api/disasters", async () => {

            var disasters = await DisasterService.GetAllDisasters();
          
            return Results.Ok(disasters);
        });

        app.MapGet("api/disasters-categories", async () => {

            var supabase = SupabaseClient.Supabase();
            var result = await supabase.From<DisasterCategory>()
            .Get();

            return Results.Ok(result.Models.ToList());
        });

        app.MapGet("api/donations", async () => {

            var supabase = SupabaseClient.Supabase();
            var result = await supabase.From<Donation>()
            .Get();

            return Results.Ok(result.Models.ToList());
        });

        app.MapGet("api/volunteers", async () => {

            var supabase = SupabaseClient.Supabase();
            var result = await supabase.From<Volunteers>()
            .Get();

            return Results.Ok(result.Models.ToList());
        });

        app.Run();

    }
}
