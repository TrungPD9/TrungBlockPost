using BasedProject.DataAccess;
using BasedProject.DataAccess.IRepositories;
using BasedProject.DataAccess.Repositories;
using BasedProject.Models.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("SQLConnection");

// Add services to the container
builder.Services.AddControllersWithViews();

// Register DbContext with Scoped lifetime
builder.Services.AddDbContext<JustBlogContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

// Register repositories
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<JustBlogContext>();
    JustBlogInitializer.Initialize(context);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
