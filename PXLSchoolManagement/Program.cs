using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var debugMode = Environment.GetEnvironmentVariable("DEBUG_MODE");
if(debugMode == null)
{
    debugMode = "default";
}

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString($"{debugMode}SqlServer"));
});

var app = builder.Build();

using (var serviceScope = app.Services
    .GetRequiredService<IServiceScopeFactory>()
    .CreateScope())
        {
    using var context = serviceScope.ServiceProvider.GetService<DataContext>();
    context.Database.Migrate();
    DatabaseInitializer.InitializeDb(context);
    
}

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
