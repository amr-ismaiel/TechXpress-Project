using Microsoft.EntityFrameworkCore;
using TechXpress_Models.Entities;
using TechXpress_DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using TechXpress_Models.IRepository;
using TechXpress_DataAccess.Repository;
using TechXpress_DataAccess.UnitOfWork;
using TechXpress_Services.Implementations;
using TechXpress_Services.Interfaces;
//using TechXpress.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TechXpress_context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TechXpress_context>();
builder.Services.AddRazorPages();

builder.Services.AddScoped<Iunitofwork , UnitOfWorkManager>();
builder.Services.AddScoped<IProductService , ProductService>();

var app = builder.Build();

//hack for quick edit remember to remove
/* var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<TechXpress_context>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated(); */

//****************************************//


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();
app.UseStaticFiles();
app.MapStaticAssets();


app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
