using HospitalModuleUser.Infra.Adapter.AccountUserAdapter;
using HospitalModuleUser.Infra.DataSource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
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

builder.Services.AddIdentity<IdentityAccountUserAdapter, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

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
