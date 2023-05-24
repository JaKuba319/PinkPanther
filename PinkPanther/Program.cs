using Microsoft.EntityFrameworkCore;
using PinkPanther.Core;
using PinkPanther.Database;
using PinkPanther.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PinkPantherDbContex>(options => 
        options.UseSqlServer("Server=.;Database=PinkPantherDatabase;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<ITypeRepository, TypeRepository>();
builder.Services.AddTransient<IRaceRepository, RaceRepository>();

builder.Services.AddTransient<DtoMapper>();
builder.Services.AddTransient<ViewModelMapper>();
builder.Services.AddTransient<IManager, Manager>();
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


using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<PinkPantherDbContex>().Database.Migrate();
}


app.Run();
