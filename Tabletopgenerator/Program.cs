using Tabletopgenerator.Models;
using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models.Entity.Login;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
ServiceCollector service = new ServiceCollector();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnection")));
service.AddServices(builder.Services);
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                            .AddEntityFrameworkStores<MyDbContext>()
                            .AddDefaultTokenProviders();
//valid for 24hours tokens

// Set token valid for 30 minutes
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(30);
});



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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
