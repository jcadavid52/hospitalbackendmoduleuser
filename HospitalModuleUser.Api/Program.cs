using System.Reflection;
using HospitalModuleUser.Infra.Adapter.AccountUserAdapter;
using HospitalModuleUser.Infra.DataSource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//fluent validation
builder.Services.AddFluentValidationAutoValidation();

//context
builder.Services.AddDbContext<DataContext>(opts =>
{
    var useInMemory = config.GetValue<bool>("UseInMemoryDatabase");

    if (useInMemory)
    {
        opts.UseInMemoryDatabase("InMemoryDb");
    }
    else
    {
        opts.UseSqlServer(config.GetConnectionString("db"));
    }
});
//identity
builder.Services.AddIdentity<IdentityAccountUserAdapter, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("HospitalModuleUser.Applica"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
