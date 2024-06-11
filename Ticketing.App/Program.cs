using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Ticketing.App.Extensions;
using Ticketing.App.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .Scan(selector => selector
            .FromAssemblies(
                Ticketing.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(
    Ticketing.Application.AssemblyReference.Assembly));

builder.Services.AddControllers();

builder.Services.AddDbContext<Ticketing.Infrastructure.ApplicationDbContext>(
    dbContextOptionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        dbContextOptionsBuilder.UseNpgsql(connectionString, npgSqlServerAction =>
        {
            npgSqlServerAction.EnableRetryOnFailure(3);
            npgSqlServerAction.CommandTimeout(30);
        });
        dbContextOptionsBuilder.EnableDetailedErrors(true);
        dbContextOptionsBuilder.EnableSensitiveDataLogging(true);
    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Type = SecuritySchemeType.Http,
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "bearer"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
