using Microsoft.EntityFrameworkCore;
using PracticeApp.Data;
using PracticeApp.Services;
using Rotativa.AspNetCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PracticeAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeAppDbContext") ?? throw new InvalidOperationException("Connection string 'PracticeAppDbContext' not found.")));

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