using SolforbTestTask.Data;
using SolforbTestTaskBlazor.Components;

namespace SolforbTestTaskBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            
            builder.Services.AddTransient<IClientService, ClientsService>();
            builder.Services.AddTransient<IReceiptsService, ReceiptsService>();
            builder.Services.AddTransient<IResourcesService, ResourcesService>();
            builder.Services.AddTransient<IMeasureUnitsService, MeasureUnitsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
