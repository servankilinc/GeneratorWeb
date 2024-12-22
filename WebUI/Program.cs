using Microsoft.EntityFrameworkCore;
using WebUI.Context;
using WebUI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
 

builder.Services.AddDbContext<LocalContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LocalDatabase")));

builder.Services.AddScoped<EntityRepository>();
builder.Services.AddScoped<DtoRepository>();
builder.Services.AddScoped<FieldRepository>();
builder.Services.AddScoped<FieldTypeRepository>();
builder.Services.AddScoped<RelationRepository>();
builder.Services.AddScoped<RelationTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
