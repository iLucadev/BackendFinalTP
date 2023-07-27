using BookLibrary;
using BookLibrary.Data;
using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Data.Repositories.Implementation;
using BookLibrary.Services;
using BookLibrary.Services.Abstract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(Program), typeof(AutoMapperProfile)); // Automatically scans and detects profiles in the service container


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
