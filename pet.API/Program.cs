using Microsoft.OpenApi.Models;
using pet.Application.Interfaces;
using pet.Application.Services;
using pet.Domain.Interfaces;
using pet.Infrastructure.ConexaoDb;
using pet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Singleton roda em segundo plano junto com a aplicação, só fecha quando encerra a aplicação
// Scoped tem início, meio e fim igual qualquer requisição

// Usando de Singleton
builder.Services.AddSingleton<DbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DbConnection(connectionString);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pet Shop API",
        Version = "v1"
    });
});

    // Add services to the container.

    builder.Services.AddControllers();

    // Usando o Scoped
    builder.Services.AddScoped<ITutorService, TutorService>();
    builder.Services.AddScoped<ITutorRepository, TutorRepository>();
    builder.Services.AddScoped<IPetRepository, PetRepository>();
    builder.Services.AddScoped<IPetService, PetService>();


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


