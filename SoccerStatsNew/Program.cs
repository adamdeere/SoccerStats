using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SoccerStatsNew.Data;
using UtilityLibraries;
using SoccerStatsNew.Services;
using SoccerStatsNew.DbServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SoccerStatsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkDbContext") 
    ?? throw new InvalidOperationException("Connection string 'SoccerStatsDbContext' not found.")));

string Address = "https://v3.football.api-sports.io/";

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);


builder.Services.AddKendo();

builder.Services.AddHttpClient<WebService>(_httpClient =>
{
    _httpClient.BaseAddress = new Uri(Address);
    _httpClient.DefaultRequestHeaders.Add(
               HeaderNames.Accept, "*/*");

    _httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");

    _httpClient.DefaultRequestHeaders.Add(
              "x-rapidapi-key", "60553e4650d7942cb159d23481c9cbba");
});

builder.Services.AddKendo(); 
builder.Services.AddScoped<CountryDbService>();
builder.Services.AddScoped<LeagueDbService>();
builder.Services.AddScoped<TeamDbService>();
builder.Services.AddScoped<VenueDbService>();
builder.Services.AddScoped<SeasonDbService>();
builder.Services.AddScoped<FixtureService>();

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