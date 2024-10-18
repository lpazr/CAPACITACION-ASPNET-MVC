using ExampleWeb.Configuration;
using ExampleWeb.Data;
using ExampleWeb.Models.Entitys;
using ExampleWeb.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//var connectionString = builder.Configuration.GetConnectionString("MyDbContext");
var connectionString = builder.Configuration["MyDbContext:ConnectionString"];
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString)
);
builder.Services.AddTransient<IValidator<Student>, StudentLogicBussinessValidator>();
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var app = builder.Build();

app.ConfigureMyApp();

app.Run();
