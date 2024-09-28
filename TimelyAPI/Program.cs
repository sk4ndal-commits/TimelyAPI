using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimelyAPI.Data;
using TimelyAPI.Models;
using TimelyAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<TimelyDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<TimelyDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<TimeLogService>();
builder.Services.AddScoped<GoalService>();
builder.Services.AddScoped<StatisticsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapControllers();

app.Run();