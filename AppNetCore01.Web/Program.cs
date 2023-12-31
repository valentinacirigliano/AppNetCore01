using AppNetCore01.DataLayer.Data;
using AppNetCore01.DataLayer.Repository.Interfaces;
using AppNetCore01.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//AGREGADO POR MI
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");





// Add services to the container.
builder.Services.AddControllersWithViews();




//AGREGADO POR MI
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options
    .UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddRazorPages();







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



//AGREGADO POR MI
app.MapRazorPages();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
