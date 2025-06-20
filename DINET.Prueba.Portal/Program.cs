using Serilog.Events;
using Serilog;
using DINET.Prueba.Helpers;
using DINET.Prueba.Portal.Services.Interfaces;
using DINET.Prueba.Portal.Services.Implementaciones;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
        .WriteTo.Console(LogEventLevel.Information)
        .WriteTo.File("logs.log",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] - {Message}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Warning)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllersWithViews();

#region[Agregar Url Apis]
builder.Services.AddHttpClientIfConfigured("ApiHttpClientDinet", builder.Configuration, "Backend:ApiRestUrlDinet");
#endregion

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region[Inyectar dependecias]
builder.Services.AddProxy<IMovInventarioProxy, MovInventarioProxy>("ApiHttpClientDinet");
#endregion

builder.Services.AddDistributedMemoryCache();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inventario}/{action=Index}/{id?}");

app.Run();
