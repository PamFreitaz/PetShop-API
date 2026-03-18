using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using pet.Application.Interfaces;
using pet.Application.Services;
using pet.Domain.Interfaces;
using pet.Infrastructure.ConexaoDb;
using pet.Infrastructure.Repositories;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwt = builder.Configuration.GetSection("Jwt");

// Singleton roda em segundo plano junto com a aplicação, só fecha quando encerra a aplicação
// Scoped tem início, meio e fim igual qualquer requisição

// CORS para autorizar o acesso do frontend — adiciona antes do builder.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Usando de Singleton
builder.Services.AddSingleton<DbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DbConnection(connectionString);
});

builder.Services.AddSingleton<IDbConnectionFactory>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DbConnection(connectionString);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!)
        )
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pet Shop API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite: Bearer {seu token JWT}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



    // Add services to the container.

    builder.Services.AddControllers();

    // Usando o Scoped
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

    builder.Services.AddScoped<IPetRepository, PetRepository>();
    builder.Services.AddScoped<IPetService, PetService>();

    builder.Services.AddScoped<IVisitaService, VisitaService>();
    builder.Services.AddScoped<IVisitaRepository, VisitaRepository>();

    builder.Services.AddScoped<IServicoService, ServicoService>();
    builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

    builder.Services.AddScoped<IProdutoService, ProdutoService>();
    builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

    builder.Services.AddScoped<IPedidoService, PedidoService>();
    builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

    builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

    builder.Services.AddScoped<ICategoriaService, CategoriaService>();
    builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

    builder.Services.AddScoped<IAuthService, AuthService>();


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

    // CORS — deve vir antes do UseAuthorization e MapControllers
    app.UseCors("PermitirFrontend");

    app.UseAuthorization();
    app.MapControllers();
    app.Run();


