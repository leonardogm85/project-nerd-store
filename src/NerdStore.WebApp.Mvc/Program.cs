using NerdStore.Catalog.Application.Extensions;
using NerdStore.Core.Extensions;
using NerdStore.Orders.Application.Extensions;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ??
    throw new InvalidOperationException("Connection string not found.");

var cultureName = builder.Configuration.GetValue<string>("AppSettings:CultureName")
    ??
    throw new InvalidOperationException("Culture name not found.");

builder.Services.AddControllersWithViews();

builder.Services
    .AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddCore();
builder.Services.AddCatalog(connectionString);
builder.Services.AddOrders(connectionString);

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/common/error");
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = new List<CultureInfo> { new(cultureName) },
    SupportedUICultures = new List<CultureInfo> { new(cultureName) },
    DefaultRequestCulture = new(cultureName)
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Showcase}/{action=Index}");
app.MapRazorPages();

app.Run();
