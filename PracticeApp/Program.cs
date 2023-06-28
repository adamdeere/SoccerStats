using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using PracticeApp.Data;
using PracticeApp.HttpServices;
using PracticeApp.Services;


var Address = "https://192.168.200.70:4911/";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PracticeAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeAppDbContext") ?? throw new InvalidOperationException("Connection string 'PracticeAppDbContext' not found.")));

// Build out the service to accept requests without a valid SSL certificate
// Nessacery to work for here but not suitable for production builds
builder.Services.AddHttpClient<ItemHttpService>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    ServerCertificateCustomValidationCallback =
           (httpRequestMessage, cert, cetChain, policyErrors) =>
           {
               return true;
           }
});




builder.Services.AddHttpClient<HttpService>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    ServerCertificateCustomValidationCallback =
           (httpRequestMessage, cert, cetChain, policyErrors) =>
           {
               return true;
           }
});

builder.Services.AddHttpClient<AnotherAbstractionService>(httpClient =>
{
    

}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    ServerCertificateCustomValidationCallback =
           (httpRequestMessage, cert, cetChain, policyErrors) =>
           {
               return true;
           }
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ReceiptService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<ItemLocationService>();

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