using Microsoft.EntityFrameworkCore;

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

builder.Services.AddControllers()
    .AddApplicationPart(Ticketing.Presentation.AssemblyReference.Assembly);

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
