using System.Reflection;
using HospitalModuleUser.Infra.Adapter.AccountUserAdapter;
using HospitalModuleUser.Infra.DataSource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using HospitalModuleUser.Infra.Extensions;
using FluentValidation;
using HospitalModuleUser.Api.Middleware;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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

builder.Services.AddDomainServices();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("HospitalModuleUser.Applica"));
});

var key = builder.Configuration.GetValue<string>("ApiSettings:SecretKey");

builder.Services.AddHttpContextAccessor();

//autenticacion
builder.Services.AddAuthentication(
     auth =>
     {
         auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

     }
    ).AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = true

        };

    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//JWT Bearer Token with swagger

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "Autenticación JWT usando el esquema Bearer. \r\n\r\n " +
            "Ingresa la palabra 'Bearer' seguido de un [espacio] y después su token en el campo de abajo.\r\n\r\n" +
            "Ejemplo: \"Bearer tkljk125jhhk\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
});

//cors
builder.Services.AddCors(p => p.AddPolicy("policyCors", build =>
 build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var defaultRole = "Usuario";
    var useInMemory = config.GetValue<bool>("UseInMemoryDatabase");
    if (useInMemory)
    {
        if (!await roleManager.RoleExistsAsync(defaultRole))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(defaultRole));

            if (result.Succeeded)
            {
                Console.WriteLine($"El rol '{defaultRole}' fue creado exitosamente.");
            }
            else
            {
                Console.WriteLine($"Error creando el rol '{defaultRole}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }


    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<AppExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("policyCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
